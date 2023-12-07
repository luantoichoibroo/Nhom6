using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoard
{
    [Serializable]
    public class CXuLyDuLieu
    {
        private Dictionary<string, CCuDan> dsCD;
        private Dictionary<string, CCanHo> dsCH;
        private List<CKhoanPhi> dsKP;
        private List<CPhuongTien> dsPT;

        public CXuLyDuLieu()
        {
            dsCD = new Dictionary<string, CCuDan>();
            dsCH = new Dictionary<string, CCanHo>();
            dsPT = new List<CPhuongTien>();
            dsKP = new List<CKhoanPhi>();
        }

        public List<CCuDan> getDSCuDan()
        {
            return dsCD.Values.ToList();
        }

        public Dictionary<string,CCuDan> idNameCuDan()
        {
            return dsCD;    
        }

        public List<CCanHo> getDsCanHo()
        {
            return dsCH.Values.ToList();
        }

        public List<CKhoanPhi> getDsKhoanPhi()
        {
            return dsKP.ToList();
        }

        public List<CPhuongTien> getDsPhuongTien()
        {
            return dsPT.ToList();
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

        public CCuDan searchCuDanTheoTen(string ten)
        {
            foreach(CCuDan item in dsCD.Values)
            {
                if(item.FullName.ToLower() == ten.ToLower())
                {
                    return item;
                }
            }
            return null;
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

        public CPhuongTien searchPhuongTien(string idCanHo)
        {
            foreach(CPhuongTien item in dsPT)
            {
                if(item.IdCanHo == idCanHo)
                {
                    return item;
                }
            }
            return null;
        }

        public CKhoanPhi searchKhoanPhi(string idCanHo)
        {
            foreach (CKhoanPhi item in dsKP)
            {
                if (item.IDCanHo == idCanHo)
                {
                    return item;
                }
            }
            return null;
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

        public bool themKhoanPhi(CKhoanPhi khoanPhi)
        {
            try
            {
                if (khoanPhi == null)
                {
                    return false;
                }
                dsKP.Add(khoanPhi);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool themPhuongTien(CPhuongTien phuongTien)
        {
            if(phuongTien.IdCanHo == null)
            {
                return false;
            }
            else
            {
                dsPT.Add(phuongTien);
                return true;
            }
        }

        public bool xoaPhuongTien(CPhuongTien phuongTien)
        {
            if (phuongTien.IdCanHo == null)
            {
                return false;
            }
            else
            {
                dsPT.Remove(phuongTien);
                return true;
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

        public bool xoaKhoanPhi(CKhoanPhi khoanPhi)
        {
            if (khoanPhi.IDCanHo == null)
            {
                return false;
            }
            else
            {
                dsKP.Remove(khoanPhi);
                return true;
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

        public void ghiFilePhuongTien()
         {
            try
            {
                FileStream file = new FileStream("DanhSachPhuongTien.dat", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(file, dsPT);
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ghiFileKhoanPhi()
        {
            try
            {
                FileStream file = new FileStream("DanhSachKhoanPhi.dat", FileMode.Create);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(file, dsKP);
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
                file.Close();
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
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void docFilePhuongTien()
        {
            try
            {
                FileStream file = new FileStream("DanhSachPhuongTien.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                dsPT = binaryFormatter.Deserialize(file) as List<CPhuongTien>;
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void docFileKhoanPhi()
        {
            try
            {
                FileStream file = new FileStream("DanhSachKhoanPhi.dat", FileMode.Open);
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                dsKP = binaryFormatter.Deserialize(file) as List<CKhoanPhi>;
                file.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
