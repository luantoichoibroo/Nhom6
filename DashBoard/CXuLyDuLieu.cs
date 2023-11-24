using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoard
{
    public class CXuLyDuLieu
    {
        private Dictionary<string, CCuDan> dsCD;
        private Dictionary<string, CCanHo> dsCH;
        private Dictionary<string, CKhoanPhi> dsKP;

        public CXuLyDuLieu()
        {
            dsCD = new Dictionary<string, CCuDan>();
            dsCH = new Dictionary<string, CCanHo>();
            dsKP = new Dictionary<string, CKhoanPhi>();
        }

        public List<CCuDan> getDSCuDan()
        {
            return dsCD.Values.ToList();
        }

        public List<CCanHo> getDsCanHo()
        {
            return dsCH.Values.ToList();
        }

        public List<CKhoanPhi> getDsKhoanPhi()
        {
            return dsKP.Values.ToList();
        }

        public CCuDan searchCuDan(string ma)
        {
            try
            {
                return dsCD[ma];
            }
            catch
            {
                return null;
            }
        }

        public CCanHo searchCanHo(string ma)
        {
            try
            {
                return dsCH[ma];
            }
            catch
            {
                return null;
            }
        }

        public CKhoanPhi searchKhoanPhi(string ma)
        {
            try
            {
                return dsKP[ma];
            }
            catch
            {
                return null;
            }
        }

        public bool themCuDan(CCuDan cuDan)
        {
            try
            {
                if (cuDan == null)
                {
                    return false;
                }
                dsCD.Add(cuDan.ID, cuDan);
                return true;
            }catch
            {
                return false;
            }
        }

        public bool themCanHo(CCanHo canHo)
        {
            try
            {
                if (canHo == null)
                {
                    return false;
                }
                dsCH.Add(canHo.ID, canHo);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCuDan(string ma)
        {
            try
            {
                return dsCD.Remove(ma);
            }
            catch
            {
                return false;
            }
        }

        public bool xoaCanHo(string ma)
        {
            try
            {
                return dsCH.Remove(ma);
            }
            catch
            {
                return false;
            }
        }

        public void ghiFileCuDan()
        {
            try
            {
                FileStream file = new FileStream("DanhSachCuDan.dat", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(file, dsCD);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ghiFileCanHo()
        {
            try
            {
                FileStream file = new FileStream("DanhSachCanHo.dat", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(file, dsCH);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void docFileCuDan()
        {
            try
            {
                FileStream file = new FileStream("DanhSachCuDan.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                dsCD = binaryFormatter.Deserialize(file) as Dictionary<string, CCuDan>;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void docFileCanHo()
        {
            try
            {
                FileStream file = new FileStream("DanhSachCanHo.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                dsCH = binaryFormatter.Deserialize(file) as Dictionary<string, CCanHo>;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
