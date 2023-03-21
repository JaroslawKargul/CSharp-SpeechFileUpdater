using Neo.IronLua;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpeechFileUpdater.Forms;

namespace SpeechFileUpdater.Utils
{
    public class DataGridWrangler
    {
        private static string NestedLevelToString(int nestedLevel)
        {
            string toReturn = String.Empty;
            while (nestedLevel > 0)
            {
                toReturn = $"{toReturn}\t";
                nestedLevel--;
            }
            return toReturn;
        }

        public static void ParseLuaTable(LuaTable luaTable, DataGridView dataGridView, string prefix = "")
        {
            IEnumerator<KeyValuePair<object, object>> enumerator = luaTable.GetEnumerator();

            while (enumerator.MoveNext())
            {
                string keyLua = enumerator.Current.Key.ToString();
                string valueLua = enumerator.Current.Value.ToString();

                if (String.IsNullOrEmpty($"{keyLua}".Trim()))
                {
                    continue;
                }

                if (enumerator.Current.Value.GetType().Name == "String")
                {
                    valueLua = MainFormUtils.RemoveMultilines(enumerator.Current.Value);
                    valueLua = valueLua.Replace("\"", "\\\"");
                }

                if (enumerator.Current.Value.GetType().Name == "LuaTable")
                {
                    string nestedPrefix = string.Empty;

                    if (!String.IsNullOrEmpty(prefix))
                    {
                        nestedPrefix = $"{prefix}.{keyLua}";
                    }
                    else
                    {
                        nestedPrefix = keyLua;
                    }

                    LuaTable luaTableNested = (LuaTable)luaTable[enumerator.Current.Key];
                    ParseLuaTable(luaTableNested, dataGridView, nestedPrefix);
                }
                else
                {
                    if (!String.IsNullOrEmpty(prefix))
                    {
                        dataGridView.Rows.Add($"{prefix}.{keyLua}", valueLua);
                    }
                    else
                    {
                        dataGridView.Rows.Add(keyLua, valueLua);
                    }
                }
            }
        }

        public static Dictionary<string, string> GetRowsWithTheSameRoot(string keysString, DataGridViewRowCollection dataRows)
        {
            string keyToLookFor = keysString.Split('.')[0];
            Dictionary<string, string> rowsWithTheSameRoot = new Dictionary<string, string>();

            if (dataRows == null)
            {
                return new Dictionary<string, string>();
            }

            foreach (DataGridViewRow dataRow in dataRows)
            {
                if (dataRow.Cells[0] == null || dataRow.Cells[0].Value == null)
                {
                    continue;
                }

                string key = dataRow.Cells[0].Value.ToString();
                string value = "";

                if (dataRow.Cells[1] != null && dataRow.Cells[1].Value != null)
                {
                    value = dataRow.Cells[1].Value.ToString();
                }

                if (key.StartsWith($"{keyToLookFor}."))
                {
                    rowsWithTheSameRoot[key] = value;
                }
            }
            return rowsWithTheSameRoot;
        }

        public static List<string> AppendNestedValuesToList(string keysString, List<string> addToList, Dictionary<string, string> rowsWithTheSameRoot, DataGridViewRowCollection dt, int nestedLevel = 1)
        {
            string keyToLookFor = keysString.Split('.')[0];
            string indent = NestedLevelToString(nestedLevel);
            string indentNested = NestedLevelToString(nestedLevel + 1);

            addToList.Add($"{indent}{keyToLookFor} ={Environment.NewLine}{indent}{{");

            List<string> processedKeys = new List<string>();

            foreach (KeyValuePair<string, string> row in rowsWithTheSameRoot)
            {
                string nestedKeyString = String.Empty;
                string nestedActualKey = String.Empty;
                if (row.Key.Contains("."))
                {
                    nestedKeyString = row.Key.Substring(keyToLookFor.Length + 1, row.Key.Length - (keyToLookFor.Length + 1));
                    nestedActualKey = nestedKeyString.Split('.')[0];
                }

                if (!String.IsNullOrEmpty(nestedKeyString) && !processedKeys.Contains(nestedActualKey))
                {
                    if (nestedKeyString.Contains("."))
                    {
                        processedKeys.Add(nestedActualKey);

                        Dictionary<string, string> rowsWithTheSameRootNested = new Dictionary<string, string>();
                        foreach (KeyValuePair<string, string> rowNested in rowsWithTheSameRoot)
                        {
                            string[] split = rowNested.Key.Split('.');
                            if (split.Length > 1 && split[1] == nestedActualKey)
                            {
                                int length = keyToLookFor.Length + nestedActualKey.Length + 2;
                                if ((rowNested.Key.Length - length) < 0)
                                {
                                    // If we got here, that means that a table key exists which is higher than our current nested level.
                                    // Example: In table #1 we have DESCRIBE.GLOMMER.GENERIC and DESCRIBE.GLOMMER.DEAD
                                    // Example: We copied DESCRIBE.GLOMMER from table #2.
                                    // In such cases, skip processing this incorrect lower-level key-value-pair.

                                    continue;
                                }

                                string x = rowNested.Key.Substring(length, rowNested.Key.Length - length);
                                rowsWithTheSameRootNested[x] = rowNested.Value;
                            }
                        }

                        List<string> newNestedList = AppendNestedValuesToList(nestedKeyString, addToList, rowsWithTheSameRootNested, dt, nestedLevel + 1);

                        addToList.Concat(newNestedList);
                    }
                    else
                    {
                        processedKeys.Add(nestedActualKey);

                        bool isNumeric = int.TryParse(nestedActualKey, out _);
                        if (isNumeric)
                        {
                            addToList.Add($"{indentNested}\"{row.Value}\",");
                        }
                        else
                        {
                            addToList.Add($"{indentNested}{nestedKeyString} = \"{row.Value}\",");
                        }
                    }
                }
                else
                {
                    if (!row.Key.Contains('.'))
                    {
                        bool isNumeric = int.TryParse(row.Key, out _);

                        if (isNumeric)
                        {
                            addToList.Add($"{indentNested}\"{row.Value}\",");
                        }
                        else
                        {
                            addToList.Add($"{indentNested}{row.Key} = \"{row.Value}\",");
                        }
                    }
                }
            }

            addToList.Add($"{indent}}},");

            return addToList;
        }

        public static void SaveDataGridAsLuaTable(string luaFilePath, DataGridView dataGridView)
        {
            List<string> luaCode = new List<string>();
            luaCode.Add("return{");

            List<string> processedRootKeys = new List<string>();

            foreach (DataGridViewRow dataRow in dataGridView.Rows)
            {
                if (dataRow.Cells[0] == null || dataRow.Cells[0].Value == null)
                {
                    continue;
                }

                string key = dataRow.Cells[0].Value.ToString();
                string keyRoot = key.Split('.')[0];
                string value = "";

                if (dataRow.Cells[1] != null && dataRow.Cells[1].Value != null)
                {
                    value = dataRow.Cells[1].Value.ToString();
                }

                if (key.Contains('.') && !processedRootKeys.Contains(keyRoot))
                {
                    processedRootKeys.Add(keyRoot);

                    Dictionary<string, string> rowsWithTheSameRoot = GetRowsWithTheSameRoot(key, dataGridView.Rows);
                    List<string> nestedList = AppendNestedValuesToList(key, luaCode, rowsWithTheSameRoot, dataGridView.Rows);
                    luaCode.Concat(nestedList);

                }
                else if (!key.Contains('.') && !processedRootKeys.Contains(keyRoot))
                {
                    processedRootKeys.Add(keyRoot);
                    luaCode.Add($"\t{key} = \"{value}\","); ;
                }
            }

            luaCode.Add("}");

            string[] luaCodeStringArray = luaCode.ToArray();

            using (StreamWriter sw = new StreamWriter(luaFilePath, false))
            {
                foreach (string luaCodeString in luaCodeStringArray)
                {
                    sw.WriteLine(luaCodeString);
                }
            }
        }

        public static Dictionary<string, int> CompareDataGridViewsAndMarkDifferences(DataGridView dataGridView, DataGridView dataGridViewToCompareTo, Form parentForm)
        {
            PleaseWaitForm pleaseWaitForm = new PleaseWaitForm();
            pleaseWaitForm.Show(parentForm);
            pleaseWaitForm.Refresh();

            List<DataGridViewRow> matchingRows = CompareDataGridViewsAndReturnMatches(dataGridViewToCompareTo, dataGridView, true);
            Dictionary<string, int> matchCounts = new Dictionary<string, int>()
            {
                ["same_keys_white"] = 0,
                ["same_keyvaluepair_yellow"] = 0,
                ["key_not_found_red"] = 0
            };

            foreach (DataGridViewRow dataRow in dataGridView.Rows)
            {
                DataGridViewRow matchingRow = matchingRows
                        .Where(row => (string)row.Cells[0].Value == (string)dataRow.Cells[0].Value).FirstOrDefault();

                if (matchingRow != null)
                {
                    string matchingRowValue = (string)matchingRow.Cells[1].Value;
                    string dataRowValue = null;

                    if (dataRow.Cells[1] != null && dataRow.Cells[1].Value != null)
                    {
                        dataRowValue = dataRow.Cells[1].Value.ToString();
                    }

                    if (matchingRowValue == dataRowValue)
                    {
                        matchCounts["same_keyvaluepair_yellow"]++;
                        dataRow.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        continue;
                    }
                }

                if (matchingRow != null)
                {
                    string matchingRowKey = (string)matchingRow.Cells[0].Value;
                    string dataRowKey = (string)dataRow.Cells[0].Value;

                    if (matchingRowKey == dataRowKey)
                    {
                        matchCounts["same_keys_white"]++;
                        dataRow.DefaultCellStyle.BackColor = Color.White;
                        continue;
                    }
                }

                matchCounts["key_not_found_red"]++;
                dataRow.DefaultCellStyle.BackColor = Color.LightPink;
            }

            pleaseWaitForm.Close();

            return matchCounts;
        }

        public static List<DataGridViewRow> CompareNestedKeys(
            string key1,
            string key2,
            bool key1IsTable,
            bool key2IsTable,
            bool forIntKeysReturnAllVersionsOfTheKeyAsRows,
            DataGridViewRow dataRow1,
            DataGridViewRow dataRow2,
            DataGridView dataGridView,
            List<DataGridViewRow> matchingRows
            )
        {
            // Key1 ends with a number (it's a table), but key2 is not.
            // So, let's check if key1 is the same as key2 if we cut off the last part of key1 from it after "." (STRING.GENERIC.1 => STRING.GENERIC)
            if (key1IsTable && !key2IsTable)
            {
                string[] split1 = key1.Split(".");
                string key1Base = String.Join('.', split1.SkipLast(1));

                if (key2 == key1Base)
                {
                    if (forIntKeysReturnAllVersionsOfTheKeyAsRows == false)
                    {
                        matchingRows.Add(dataRow1);
                    }
                    else
                    {
                        // Create version of the row with different key, but a value that never matches
                        // (newline, which we normally remove when loading data into table)
                        // This is so that we can look for duplicates by values easily later on
                        DataGridViewRow clonedRow = (DataGridViewRow)dataRow2.Clone();
                        clonedRow.Cells[0].Value = key2;
                        clonedRow.Cells[1].Value = $"\n";

                        // Add all versions of this row into our list
                        matchingRows.Add(dataRow1);
                        matchingRows.Add(clonedRow);
                    }
                }
            }
            // Do the same for key2...
            else if (!key1IsTable && key2IsTable)
            {
                string[] split2 = key2.Split(".");
                string key2Base = String.Join('.', split2.SkipLast(1));

                if (key1 == key2Base)
                {
                    if (forIntKeysReturnAllVersionsOfTheKeyAsRows == false)
                    {
                        matchingRows.Add(dataRow1);
                    }
                    else
                    {
                        DataGridViewRow clonedRow = (DataGridViewRow)dataRow2.Clone();
                        clonedRow.Cells[0].Value = key2;
                        clonedRow.Cells[1].Value = "\n";

                        // Add all versions of this row into our list
                        matchingRows.Add(dataRow1);
                        matchingRows.Add(clonedRow);
                    }
                }
            }
            // Also, ignore additional values for keys if both keys are tables already - the keys should be treated as 'matching'
            // (e.g. table 1 has DESCRIBE.THING.9 and table 2 has DESCRIBE.THING.10 - ignore the fact that table 2 has an additional 10th value)
            else if (key1IsTable && key2IsTable)
            {
                string[] split1 = key1.Split(".");
                string key1Base = String.Join('.', split1.SkipLast(1));

                string[] split2 = key2.Split(".");
                string key2Base = String.Join('.', split2.SkipLast(1));

                if (key1Base == key2Base)
                {
                    // Check if key2 exists in first dataGridView, and if it does, skip current check
                    bool keyAlreadyExists = false;
                    foreach (DataGridViewRow x in dataGridView.Rows)
                    {
                        if ((string)x.Cells[0].Value == key2)
                        {
                            keyAlreadyExists = true;
                            break;
                        }
                    }

                    if (keyAlreadyExists)
                    {
                        return matchingRows;
                    }

                    if (forIntKeysReturnAllVersionsOfTheKeyAsRows == false)
                    {
                        matchingRows.Add(dataRow1);
                    }
                    else
                    {
                        DataGridViewRow clonedRow = (DataGridViewRow)dataRow2.Clone();
                        clonedRow.Cells[0].Value = key2;
                        clonedRow.Cells[1].Value = "\n";

                        DataGridViewRow clonedRow2 = (DataGridViewRow)dataRow2.Clone();
                        clonedRow2.Cells[0].Value = key2Base;
                        clonedRow2.Cells[1].Value = "\n";

                        // Add all versions of this row into our list
                        matchingRows.Add(dataRow1);
                        matchingRows.Add(clonedRow);
                        matchingRows.Add(clonedRow2);
                    }
                }
            }
            return matchingRows;
        }

        public static List<DataGridViewRow> CompareDataGridViewsAndReturnMatches(DataGridView dataGridView, DataGridView dataGridViewToCompareTo, bool forIntKeysReturnAllVersionsOfTheKeyAsRows = false)
        {
            List<DataGridViewRow> matchingRows = new List<DataGridViewRow>();

            foreach (DataGridViewRow dataRow1 in dataGridView.Rows)
            {
                if (dataRow1.Cells[0] == null || dataRow1.Cells[0].Value == null)
                {
                    continue;
                }

                string key1 = dataRow1.Cells[0].Value.ToString();
                string value1 = "";

                if (dataRow1.Cells[1] != null && dataRow1.Cells[1].Value != null)
                {
                    value1 = dataRow1.Cells[1].Value.ToString();
                }

                bool key1IsTable = false;
                if (key1.Contains("."))
                {
                    string[] split = key1.Split('.');
                    string lastPartOfKey = split[split.Length - 1];
                    key1IsTable = int.TryParse(lastPartOfKey, out _);
                }

                foreach (DataGridViewRow dataRow2 in dataGridViewToCompareTo.Rows)
                {
                    string key2 = dataRow2.Cells[0].Value.ToString();
                    string value2 = "";

                    if (dataRow2.Cells[1] != null && dataRow2.Cells[1].Value != null)
                    {
                        value2 = dataRow2.Cells[1].Value.ToString();
                    }

                    bool key2IsTable = false;
                    if (key2.Contains("."))
                    {
                        string[] split = key2.Split('.');
                        string lastPartOfKey = split[split.Length - 1];
                        key2IsTable = int.TryParse(lastPartOfKey, out _);
                    }

                    if (key2 == key1)
                    {
                        matchingRows.Add(dataRow1);
                    }
                    else
                    {
                        matchingRows = CompareNestedKeys(key1, key2, key1IsTable, key2IsTable,
                            forIntKeysReturnAllVersionsOfTheKeyAsRows, dataRow1, dataRow2,
                            dataGridView, matchingRows);
                    }
                }
            }

            return matchingRows;
        }

        public static void HideNotMatchingDataGridViewRows(DataGridView dataGridView, string stringToMatch)
        {
            DataGridViewRow[] theRows = new DataGridViewRow[dataGridView.Rows.Count];
            dataGridView.Rows.CopyTo(theRows, 0);
            dataGridView.Rows.Clear();
            for (int loop = 0; loop < theRows.Length; loop++)
            {
                string key = (string)theRows[loop].Cells[0].Value;
                string value = null;

                if (theRows[loop].Cells[1] != null && theRows[loop].Cells[1].Value != null)
                {
                    value = theRows[loop].Cells[1].Value.ToString();
                }

                bool keyContains = key.IndexOf(stringToMatch, StringComparison.OrdinalIgnoreCase) >= 0;
                bool valueContains = value.IndexOf(stringToMatch, StringComparison.OrdinalIgnoreCase) >= 0;

                if (!keyContains && !valueContains)
                {
                    theRows[loop].Visible = false;
                }
                else
                {
                    theRows[loop].Visible = true;
                }
            }
            dataGridView.Rows.AddRange(theRows);
        }

        public static void CopyMissingKeysBetweenDataGrids(Form parentForm, DataGridView dgCopyFrom, DataGridView dgCopyTo)
        {
            PleaseWaitForm pleaseWaitForm = new PleaseWaitForm();
            pleaseWaitForm.Show(parentForm);
            pleaseWaitForm.Refresh();

            // Copy missing keys from table "dgCopyFrom" to table "dgCopyTo"
            List<DataGridViewRow> matchingRows = CompareDataGridViewsAndReturnMatches(dgCopyFrom, dgCopyTo);
            List<DataGridViewRow> notMatchingRows = new List<DataGridViewRow>();
            int rowsCopied = 0;

            foreach (DataGridViewRow dataRow in dgCopyFrom.Rows)
            {
                if (!matchingRows.Contains(dataRow))
                {
                    notMatchingRows.Add(dataRow);
                }
            }

            foreach (DataGridViewRow dataRow in notMatchingRows)
            {
                DataGridViewRow row = (DataGridViewRow)dgCopyTo.Rows[0].Clone();

                string currentDataRowKey = dataRow.Cells[0].Value.ToString().Trim();
                row.Cells[0].Value = currentDataRowKey;

                string currentDataRowValue = null;

                if (dataRow.Cells[1] != null && dataRow.Cells[1].Value != null)
                {
                    currentDataRowValue = dataRow.Cells[1].Value.ToString();
                }

                if (currentDataRowValue != null && !currentDataRowValue.StartsWith("only_used_by_"))
                {
                    row.Cells[1].Value = "";
                }
                else
                {
                    // Uncomment below line and remove 'continue' to copy 'only_used_by_x' values
                    //row.Cells[1].Value = currentDataRowValue;
                    continue;
                }

                // Additionally, ignore copying key-value pairs for keys which we have in the table already
                // Example#1: If we have "DESCRIBE.GLOMMER" then skip copying "DESCRIBE.GLOMMER.GENERIC".
                // Example#2: If we have "DESCRIBE.GLOMMER.DEAD" then skip copying "DESCRIBE.GLOMMER".
                bool shouldSkip = false;
                foreach (DataGridViewRow _dataRow in dgCopyTo.Rows)
                {
                    string _dataRowKey = $"{_dataRow.Cells[0].Value}.";
                    if (_dataRowKey.StartsWith($"{currentDataRowKey}.") ||
                        currentDataRowKey.StartsWith(_dataRowKey))
                    {
                        shouldSkip = true;
                        break;
                    }
                }
                if (shouldSkip)
                {
                    continue;
                }

                rowsCopied++;
                dgCopyTo.Rows.Add(row);
            }

            pleaseWaitForm.Close();

            if (rowsCopied > 0)
            {
                string tableLocation = "right";
                if (dgCopyTo.Name == "dataGridView1")
                {
                    tableLocation = "left";
                }

                string labelText = $"New keys (count: {rowsCopied}) were copied to the bottom of {tableLocation} table.";
                string titleText = "Copy Missing Keys";
                MainFormUtils.ShowPopUp(parentForm, titleText, labelText, true);
            }
            else
            {
                string labelText = "No new keys to copy could be found.";
                string titleText = "Copy Missing Keys";
                MainFormUtils.ShowPopUp(parentForm, titleText, labelText, true);
            }
        }

        public static void PutEmptyLinesOnTheBottom(DataGridView dataGridView)
        {
            List<DataGridViewRow> emptyRows = new List<DataGridViewRow>();
            List<DataGridViewRow> notEmptyRows = new List<DataGridViewRow>();

            DataGridViewRow[] theRows = new DataGridViewRow[dataGridView.Rows.Count];
            dataGridView.Rows.CopyTo(theRows, 0);
            dataGridView.Rows.Clear();
            for (int loop = 0; loop < theRows.Length; loop++)
            {
                string value = null;

                if (theRows[loop].Cells[1] != null && theRows[loop].Cells[1].Value != null)
                {
                    value = theRows[loop].Cells[1].Value.ToString();
                }

                bool valueIsEmpty = false;
                if (String.IsNullOrEmpty($"{value}".Trim()))
                {
                    valueIsEmpty = true;
                }

                if (valueIsEmpty)
                {
                    emptyRows.Add(theRows[loop]);
                }
                else
                {
                    notEmptyRows.Add(theRows[loop]);
                }
            }

            List<DataGridViewRow> sortedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in notEmptyRows)
            {
                sortedRows.Add(row);
            }
            foreach (DataGridViewRow row in emptyRows)
            {
                sortedRows.Add(row);
            }

            DataGridViewRow[] theSortedRows = new DataGridViewRow[theRows.Length];
            sortedRows.CopyTo(theSortedRows, 0);
            dataGridView.Rows.AddRange(theSortedRows);
        }
    }
}
