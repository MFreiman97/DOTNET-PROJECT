using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;
using DS;
using System.Reflection;
using System.ComponentModel;

namespace DAL
{
   public class Dal_XML_imp : Idal
    {
      
        public int Contnum=0;
        public Dal_XML_imp()
        {  
     
            if (!File.Exists(ChildPath))
                CreateFiles();
            else
                LoadData();
            if (!File.Exists(ContNUMPath))
            {
                CONTNUMROOT = new XElement("Key", Contnum);
                CONTNUMROOT.Save(ContNUMPath);
           
           
            }
            else
                CONTNUMROOT= XElement.Load(ContNUMPath);




        }//

        private void CreateFiles()
        {
            ChildRoot = new XElement("Child");
           
            ChildRoot.Save(ChildPath);
         
        }//

        private void LoadData()///////
        {
          
                ChildRoot = XElement.Load(ChildPath);
                try
                {
                    DataSource.childs = (from stu in ChildRoot.Elements()
                                         select new Child()
                                         {
                                             id = int.Parse(stu.Element("id").Value),
                                             name = stu.Element("OtherDetails").Element("firstName").Value,
                                             momId = int.Parse(stu.Element("OtherDetails").Element("Motherid").Value),
                                             nannyID = int.Parse(stu.Element("OtherDetails").Element("Nannyid").Value),
                                             kindSpecial = stu.Element("kindSpecial").Value,
                                             special = bool.Parse(stu.Element("special").Value),
                                             birth = DateTime.Parse(stu.Element("OtherDetails").Element("birth").Value),
                                         


                                         }).ToList();
          
            }
                catch
                {
               
                
                }
           
          
        }//
   
   public     XElement  ChildRoot;
        public XElement CONTNUMROOT;
     public   string ChildPath = @"ChildXml.xml";
        public string ContNUMPath = @"ContNUM.xml";
        public string MotherPath = @"MotherXml.xml";
      public  string NannyPath = @"NannyXml.xml";
     public   string ContractPath = @"ContractXml.xml";
        public void addChild(Child c)//*************************
        {
            if (GetChild(c.id) == null)
            {
           
                XElement firstName = new XElement("firstName", c.name);


                XElement birth = new XElement("birth", c.birth);
                XElement id = new XElement("id", c.id);
                XElement special = new XElement("special", c.special);
                XElement kindSpecial = new XElement("kindSpecial", c.kindSpecial);
                XElement Nannyid = new XElement("Nannyid", c.nannyID);
                XElement Motherid = new XElement("Motherid", c.momId);
                XElement OtherDetails = new XElement("OtherDetails", firstName, Nannyid, birth, Motherid);
                XElement FullName = new XElement("FullName", c.FullName);
                ChildRoot.Add(new XElement("Child", id, OtherDetails, special, kindSpecial, FullName));
                ChildRoot.Save(ChildPath);
            }
        }
         public void deleteChild(Child c)
        {
            XElement ChildElement;
            try
            {
                ChildElement = (from p in ChildRoot.Elements()
                                  where Convert.ToInt32(p.Element("id").Value) == c.id
                                  select p).FirstOrDefault();
                ChildElement.Remove();
                ChildRoot.Save(ChildPath);
              
            }
            catch
            {
                new Exception("The Child you tried to remove wasnt exist");
            }
        }//*********************
       public IEnumerable<Child> GetAllChildsByMother(Mother m)
        {
            var v = GetAllChilds();
            return v.Where(i => (i.momId) == m.id);
        }//***********************
     public IEnumerable<Child> GetAllChilds(Func<Child, bool> predicat = null)//**************
        {

            if (predicat == null)
            {
                return from item in ChildRoot.Elements()
                       select ConvertChild(item);
            }

            return from item in ChildRoot.Elements()
                   let s = ConvertChild(item)
                   where predicat(s)
                   select s;





        }//

        private Child ConvertChild(XElement ChildElement)
        {
            Child ch = new Child();


            ch.id = int.Parse(ChildElement.Element("id").Value);
            int result;
            if (int.TryParse(ChildElement.Element("OtherDetails").Element("Nannyid").Value, out result) == true)
                ch.nannyID = int.Parse(ChildElement.Element("OtherDetails").Element("Nannyid").Value);
            else
                ch.nannyID = null;
            ch.momId = int.Parse(ChildElement.Element("OtherDetails").Element("Motherid").Value);
            ch.name = ChildElement.Element("OtherDetails").Element("firstName").Value;
            ch.birth = DateTime.Parse(ChildElement.Element("OtherDetails").Element("birth").Value);
            ch.special = bool.Parse(ChildElement.Element("special").Value);
            ch.kindSpecial=ChildElement.Element("kindSpecial").Value;
            ch.FullName = ChildElement.Element("FullName").Value;

            return ch;
        }//*********************

        public Child GetChild(int id)
        {
            XElement c = null;

            try
            {
                c = (from item in ChildRoot.Elements()
                       where int.Parse(item.Element("id").Value) == id
                       select item).FirstOrDefault();
            }
            catch (Exception)
            {
                return null;
            }

            if (c == null)
                return null;
            Child ch = new Child();

            ch = ConvertChild(c);

            return ch;


        }//*****************
        public void updateChild(Child c)
        {
            XElement ChildElement = (from p in ChildRoot.Elements()
                                       where Convert.ToInt32(p.Element("id").Value) == c.id
                                       select p).FirstOrDefault();

            ChildElement.Element("id").Value = c.id.ToString();
            ChildElement.Element("OtherDetails").Element("Nannyid").Value = c.nannyID.ToString();
            ChildElement.Element("OtherDetails").Element("Motherid").Value = c.momId.ToString();
            ChildElement.Element("OtherDetails").Element("firstName").Value = c.name;
            ChildElement.Element("OtherDetails").Element("birth").Value = c.birth.ToString();
            ChildElement.Element("special").Value = c.special.ToString();
            ChildElement.Element("kindSpecial").Value = c.kindSpecial;
            ChildElement.Element("FullName").Value = c.FullName;
            ChildRoot.Save(ChildPath);

        }//*****************


         public static void SaveToXML<T>(List<T> source, string path)
        {
            FileStream file = new FileStream(path, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
            xmlSerializer.Serialize(file, source);
            file.Close();
        }
        public static List<T> LoadFromXML<T>(string path)
        {      if (!File.Exists(path))
            {
                FileStream file_ = new FileStream(path, FileMode.Create);
                XmlSerializer xmlSerializer_ = new XmlSerializer(typeof(List<T>));
                xmlSerializer_.Serialize(file_,new List<T>());
                file_.Close();
            }
                FileStream file = new FileStream(path, FileMode.OpenOrCreate);
       
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<T>));
                List<T> result = (List<T>)xmlSerializer.Deserialize(file);
                file.Close();
                return result;
                
        }
        private int GetContnum()
        {
        
            try
            {
                return int.Parse(CONTNUMROOT.Value);
            }
            catch (Exception)
            {

               return -1;
            }
       
        }
        private void UpdateContnum(int number)
        {
            number++;

            CONTNUMROOT.Value = number.ToString();
            CONTNUMROOT.Save(ContNUMPath);

        }

        public void addContract(Contract c)
        {
            List<Contract> ContractList = LoadFromXML<Contract>(ContractPath).ToList();
            List<Nanny> NannyList = LoadFromXML<Nanny>(NannyPath).ToList();
            var childs = GetAllChilds().ToList();
            Child temp = childs.Find(x => x.id == c.ChildId);
            
      Nanny na=      NannyList.Find(n => n.id == c.n.id);
            temp.nannyID = na.id;
            na.contracts++;
            na.MonthSalary += c.SalaryPerMonth;
            updateNanny(na);

            updateChild(temp);

            c.n.contracts++;
               c.contnum = GetContnum();
           UpdateContnum(c.contnum);
            ContractList.Add(c);
            SaveToXML<Nanny>(NannyList, NannyPath);
            SaveToXML<Contract>(ContractList, ContractPath);


        }//****************
        public void SaveContracts()
        {
            FileStream file = new FileStream(ContractPath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(DataSource.contracts.GetType());
            xmlSerializer.Serialize(file, DataSource.contracts);
            file.Close();
        }

        public void addMom(Mother mo)
        {
            List<Mother> MotherList = LoadFromXML<Mother>(MotherPath).ToList();
        var temp=    MotherList.Find(m => m.id == mo.id);
            if (temp != null)
            {
                return;

            }
            MotherList.Add(mo);
            SaveToXML<Mother>(MotherList, MotherPath);

        }//****************

        public void SaveMothers()
        {
            FileStream file = new FileStream(MotherPath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(DataSource.mothers.GetType());
            xmlSerializer.Serialize(file, DataSource.mothers);
            file.Close();
        }

        public void addNanny(Nanny n)
        {
            List<Nanny> NannyList = LoadFromXML<Nanny>(NannyPath).ToList();
            var temp = NannyList.Find(na => na.id == n.id);
            if (temp != null)
            {
                return;
            }
            NannyList.Add(n);
            SaveToXML<Nanny>(NannyList, NannyPath);
        }//****************

        public void SaveNannies()
        {
            FileStream file = new FileStream(NannyPath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(DataSource.nannies.GetType());
            xmlSerializer.Serialize(file, DataSource.nannies);
            file.Close();
        }

     

        public void deleteContract(Contract c)//????????????????????
        {
            List<Contract> ContractList = LoadFromXML<Contract>(ContractPath);
            Nanny n = GetNanny(c.n.id);
            n.contracts--;
            n.MonthSalary = n.MonthSalary - c.SalaryPerMonth;
            updateNanny(n);
            Child chi = GetChild(c.ChildId);
            chi.nannyID = null;
            updateChild(chi);
            var x = ContractList.RemoveAll(con => con.contnum == c.contnum);
            if (x == 0)
                throw new Exception("No such contract was found");
            SaveToXML<Contract>(ContractList, ContractPath);

        }//**********
       

        public void deleteMom(Mother m)
        {
            if (GetMother(m.id) != null)
            {

                List<Mother> MotherList = LoadFromXML<Mother>(MotherPath);
                int index =MotherList.FindIndex(x => x.id == m.id);
                if (index != -1)
                {
                   MotherList.RemoveAt(index);

                }
                SaveToXML<Mother>(MotherList, MotherPath);
          

            }
           
            else
                throw new Exception("the Mother you tried to delete wasnt exist!");

        }//********************

        public void deleteNanny(Nanny n)
        {
            if (GetNanny(n.id) != null)
            {
                List<Nanny> NannyList = LoadFromXML<Nanny>(NannyPath);
                int index =NannyList.FindIndex(x => x.id == n.id);// i need to use the icomparable 
                if (index != -1)
                {
                   NannyList.RemoveAt(index);

                }
                SaveToXML<Nanny>(NannyList, NannyPath);

            }
            else
                throw new Exception("the Nanny you tried to delete wasnt exist!");

        }//*****************

   

       

        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            var v= LoadFromXML<Contract>(ContractPath);
            if (predicat != null) 
            return v.Where(predicat).AsEnumerable();
            return v.AsEnumerable();

        }//******************

        private void LoadContracts()
        {
            FileStream file = new FileStream(ContractPath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Contract>));
            DataSource.contracts = (List<Contract>)xmlSerializer.Deserialize(file);
            file.Close();
        }

        public IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null)
        {
            var v = LoadFromXML<Mother>(MotherPath);
            if (predicat != null)
                return v.Where(predicat).AsEnumerable();
            else
                return v.AsEnumerable();

        }//***************

        private void LoadMothers()
        {
            FileStream file = new FileStream(MotherPath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Mother>));
            DataSource.mothers = (List<Mother>)xmlSerializer.Deserialize(file);
            file.Close();
        }

        public IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null)
        {
            var v = LoadFromXML<Nanny>(NannyPath);
            if (predicat != null)
                return v.Where(predicat).AsEnumerable();
            else
                return v.AsEnumerable();

        }//*****************

        private void LoadNannies()
        {
            FileStream file = new FileStream(NannyPath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Nanny>));
            DataSource.nannies = (List<Nanny>)xmlSerializer.Deserialize(file);
            file.Close();
        }

   

        public Contract GetContract(int cont)
        {
            var v = LoadFromXML<Contract>(ContractPath);
            return v.Find(x => x.contnum == cont);

        }//******************

        public Mother GetMother(int id)
        {
            var v = LoadFromXML<Mother>(MotherPath);
            return v.Find(x => x.id == id);
        }//***************8

        public Nanny GetNanny(int id)
        {
            var v = LoadFromXML<Nanny>(NannyPath);
            return v.Find(x => x.id == id);
        }//***************

       

        public void updateContract(Contract c)
        {
            List<Contract> ListContract = LoadFromXML<Contract>(ContractPath);
            int index = ListContract.FindIndex(x => x.contnum == c.contnum);// i need to use the icomparable 
            if (index != -1)
            {
              ListContract[index] = c;
                SaveToXML<Contract>(ListContract, ContractPath);
            }
        }

        public void updateMom(Mother m)
        {
            List<Mother> ListMother = LoadFromXML<Mother>(MotherPath);
            int index = ListMother.FindIndex(x => x.id ==m.id);// i need to use the icomparable 
            if (index != -1)
            {
               ListMother[index] = m;
                SaveToXML<Mother>(ListMother, MotherPath);

            }
        }

        public void updateNanny(Nanny n)
        {
            List<Nanny> ListNanny = LoadFromXML<Nanny>(NannyPath);
            int index = ListNanny.FindIndex(x => x.id == n.id);// i need to use the icomparable 
            if (index != -1)
            {
             ListNanny[index] = n;
                SaveToXML<Nanny>(ListNanny, NannyPath);

            }

        }
    }
}
