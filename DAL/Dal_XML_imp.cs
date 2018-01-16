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
namespace DAL
{
   public class Dal_XML_imp : Idal
    {
        public static int Contnum = 1;
        public Dal_XML_imp()
        {  LoadMothers();
            LoadNannies();
           
     
            if (!File.Exists(ChildPath))
                CreateFiles();
            else
                LoadData();
              LoadContracts();
          



        }//

        private void CreateFiles()
        {
            ChildRoot = new XElement("Child");
            ChildRoot.Save(ChildPath);
        }//

        private void LoadData()
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
                                             mom = GetMother(int.Parse(stu.Element("OtherDetails").Element("Motherid").Value))


                                         }).ToList();

                }
                catch
                {
               
                
                }
           
          
        }//

   public     XElement  ChildRoot;
     public   string ChildPath = @"ChildXml.xml";
       public string MotherPath = @"MotherXml.xml";
      public  string NannyPath = @"NannyXml.xml";
     public   string ContractPath = @"ContractXml.xml";
        public void addChild(Child c)
        {
            if (GetChild(c.id) == null)
            {
                DataSource.childs.Add(c);
                XElement firstName = new XElement("firstName", c.name);


                XElement birth = new XElement("birth", c.birth);
                XElement id = new XElement("id", c.id);
                XElement special = new XElement("special", c.special);
                XElement kindSpecial = new XElement("kindSpecial", c.kindSpecial);

                XElement Nannyid = new XElement("Nannyid", c.nannyID);
                XElement Motherid = new XElement("Motherid", c.momId);
                XElement OtherDetails = new XElement("OtherDetails", firstName, Nannyid, birth, Motherid);
                ChildRoot.Add(new XElement("Child", id, OtherDetails, special, kindSpecial));
                ChildRoot.Save(ChildPath);
            }
        }

        public void addContract(Contract c)
        {
            DataSource.contracts.Add(c);
            c.n.contracts++;
            c.contnum = Contnum++;
            SaveContracts();
        }//

        private void SaveContracts()
        {
            FileStream file = new FileStream(ContractPath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(DataSource.contracts.GetType());
            xmlSerializer.Serialize(file, DataSource.contracts);
            file.Close();
        }

        public void addMom(Mother m)
        {
            if (GetMother(m.id) == null)
            {
                DataSource.mothers.Add(m);
            }
            SaveMothers();
        }//

        private void SaveMothers()
        {
            FileStream file = new FileStream(MotherPath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(DataSource.mothers.GetType());
            xmlSerializer.Serialize(file, DataSource.mothers);
            file.Close();
        }

        public void addNanny(Nanny n)
        {
            if (GetNanny(n.id) == null)
            DataSource.nannies.Add(n);
            SaveNannies();
        }//

        private void SaveNannies()
        {
            FileStream file = new FileStream(NannyPath, FileMode.Create);
            XmlSerializer xmlSerializer = new XmlSerializer(DataSource.nannies.GetType());
            xmlSerializer.Serialize(file, DataSource.nannies);
            file.Close();
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
                DataSource.childs.Remove(c);
            }
            catch
            {
                new Exception("The Child you tried to remove wasnt exist");
            }
        }

        public void deleteContract(Contract c)
        {
            if (GetContract(c.contnum) != null)
            {
                c.n.contracts--;
    
                int index = DataSource.contracts.FindIndex(x => x.contnum == c.contnum);// i need to use the icomparable 
                if (index != -1)
                {
                    DataSource.contracts.RemoveAt(index);
                   
                }
                SaveContracts();
                LoadContracts();
            
            }
            else
                throw new Exception("the Contract you tried to delete wasnt exist!");

        }//

        public void deleteMom(Mother m)
        {
            if (GetMother(m.id) != null)
            {
               

                int index = DataSource.mothers.FindIndex(x => x.id == m.id);// i need to use the icomparable 
                if (index != -1)
                {
                    DataSource.mothers.RemoveAt(index);

                }
                SaveMothers();
                LoadMothers();

            }
           
            else
                throw new Exception("the Mother you tried to delete wasnt exist!");

        }

        public void deleteNanny(Nanny n)
        {
            if (GetNanny(n.id) != null)
            {
                int index = DataSource.nannies.FindIndex(x => x.id == n.id);// i need to use the icomparable 
                if (index != -1)
                {
                    DataSource.nannies.RemoveAt(index);

                }
                SaveNannies();
                LoadNannies();

            }
            else
                throw new Exception("the Nanny you tried to delete wasnt exist!");

        }

        public IEnumerable<Child> GetAllChilds(Func<Child, bool> predicat = null)//need to be linqto xml
        {
            LoadData();


            if (predicat == null)
                return DataSource.childs.AsEnumerable();

            return DataSource.childs.Where(predicat);




        }//

        public IEnumerable<Child> GetAllChildsByMother(Mother m)
        {
            var v = GetAllChilds();
            return v.Where(i => i.mom.id == m.id);
        }//

        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            LoadContracts();
            if (predicat == null)
                return DataSource.contracts.AsEnumerable();

            return DataSource.contracts.Where(predicat);

        }//

        private void LoadContracts()
        {
            FileStream file = new FileStream(ContractPath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Contract>));
            DataSource.contracts = (List<Contract>)xmlSerializer.Deserialize(file);
            file.Close();
        }

        public IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null)
        {
            LoadMothers();
            if (predicat == null)
                return DataSource.mothers.AsEnumerable();

            return DataSource.mothers.Where(predicat);

        }//

        private void LoadMothers()
        {
            FileStream file = new FileStream(MotherPath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Mother>));
            DataSource.mothers = (List<Mother>)xmlSerializer.Deserialize(file);
            file.Close();
        }

        public IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null)
        {
            LoadNannies();
            if (predicat == null)
                return DataSource.nannies.AsEnumerable();

            return DataSource.nannies.Where(predicat);

        }//

        private void LoadNannies()
        {
            FileStream file = new FileStream(NannyPath, FileMode.Open);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Nanny>));
            DataSource.nannies = (List<Nanny>)xmlSerializer.Deserialize(file);
            file.Close();
        }

        public Child GetChild(int id)
        {
              LoadData();
            return DataSource.childs.Find(c => c.id == id);
        }

        public Contract GetContract(int cont)
        {
            LoadContracts();
            return DataSource.contracts.Find(n => n.contnum == cont);

        }//

        public Mother GetMother(int id)
        {
            LoadMothers();
            return DataSource.mothers.Find(m => m.id == id);
        }

        public Nanny GetNanny(int id)
        {
            LoadNannies();
            return DataSource.nannies.Find(n => n.id == id);
        }

        public void updateChild(Child c)
        {
            XElement ChildElement = (from p in ChildRoot.Elements()
                                       where Convert.ToInt32(p.Element("id").Value) == c.id
                                       select p).FirstOrDefault();

            ChildElement.Element("id").Value = c.id.ToString();
            ChildElement.Element("OtherDetails").Element("Nannyid").Value = c.nannyID.ToString();
            ChildElement.Element("OtherDetails").Element("Motherid").Value = c.momId.ToString();
            ChildElement.Element("OtherDetails").Element("firstName").Value = c.name;
            ChildElement.Element("OtherDetails").Element("birth").Element("year").Value = c.birth.Year.ToString();
            ChildElement.Element("OtherDetails").Element("birth").Element("month").Value = c.birth.Month.ToString();
            ChildElement.Element("OtherDetails").Element("birth").Element("day").Value = c.birth.Day.ToString();

            ChildRoot.Save(ChildPath);
        }//

        public void updateContract(Contract c)
        {
            LoadContracts();
            int index = DataSource.contracts.FindIndex(x => x.contnum == c.contnum);// i need to use the icomparable 
            if (index != -1)
            {
                DataSource.contracts[index] = c;
                SaveContracts();
            }
        }

        public void updateMom(Mother m)
        {
            LoadMothers();
            int index = DataSource.mothers.FindIndex(x => x.id ==m.id);// i need to use the icomparable 
            if (index != -1)
            {
                DataSource.mothers[index] = m;
                SaveMothers();

            }
        }

        public void updateNanny(Nanny n)
        {
            LoadNannies();
            int index = DataSource.nannies.FindIndex(x => x.id == n.id);// i need to use the icomparable 
            if (index != -1)
            {
                DataSource.nannies[index] = n;
                SaveNannies();

            }

        }
    }
}
