using System;
using System.Data;
using System.Reflection;

namespace BuscaCEP.model
{
    class CamposSQL
    {
        #region Metodo de Carregamento
        public class SetarCampos
        {
            public static void RetonarValor(IDataReader oIDataReader, object pthis)
            {
                foreach (FieldInfo aField in pthis.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic))
                {
                    try
                    {
                        switch (aField.FieldType.Name.ToString().ToLower())
                        {
                            case "float":
                            case "double":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToDouble(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToDouble(-1));
                                break;
                            case "byte":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToByte(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToByte(-1));
                                break;
                            case "datetime":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToDateTime(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToDateTime("01/01/1900 00:00:00"));
                                break;
                            case "datetime2":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToDateTime(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToDateTime("01/01/1900 00:00:00"));
                                break;
                            case "string":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToString(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, string.Empty.ToString());
                                break;
                            case "int16":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToInt16(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToInt16(-1));
                                break;
                            case "int32":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToInt32(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToInt32(-1));
                                break;
                            case "int64":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToInt64(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToInt64(-1));
                                break;
                            case "boolean":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToBoolean(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToBoolean(false));
                                break;
                            case "decimal":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, Convert.ToDecimal(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1)))));
                                else
                                    aField.SetValue(pthis, Convert.ToDecimal(-1));
                                break;
                            case "byte[]":
                                if (oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))) != DBNull.Value)
                                    aField.SetValue(pthis, oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))));
                                else
                                    aField.SetValue(pthis, null);
                                break;
                            default:
                                if (aField.FieldType.Name.Substring(0, 3) != "Tab" && aField.FieldType.Name.Substring(0, 10) != "ListaClass")
                                    aField.SetValue(pthis, Convert.ChangeType(oIDataReader.GetValue(oIDataReader.GetOrdinal(aField.Name.Remove(0, 1))), aField.FieldType));
                                break;
                        }
                    }
                    catch { }
                }
            }
        }
        #endregion
    }
}
