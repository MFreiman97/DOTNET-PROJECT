using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using System.Xml.Linq;
using System.IO;

namespace DAL
{
   public class Dal_XML_imp : Idal
    {
        public Dal_XML_imp()
        {
            if (!File.Exists(ChildPath))
                CreateFiles();
            else
                LoadData();
        }

        private void CreateFiles()
        {
            ChildRoot = new XElement("Child");
            ChildRoot.Save(ChildPath);
        }

        private void LoadData()
        {
            try
            {
                ChildRoot = XElement.Load(ChildPath);
            }
            catch
            {
                throw new Exception("File upload problem");
            }
        }

        XElement  ChildRoot;
        string ChildPath = @"ChildXml.xml";
        public void addChild(Child c)
        {
         
            XElement firstName = new XElement("firstName", c.name);
            XElement year = new XElement("year", c.birth.Year);
            XElement month = new XElement("month", c.birth.Month);
            XElement day = new XElement("day", c.birth.Day);

            XElement birth = new XElement("birth",year,month,day);
            XElement id = new XElement("id", c.id);
            XElement Nannyid = new XElement("Nannyid", c.nannyID);
            XElement Motherid = new XElement("Motherid", c.momId);
            XElement OtherDetails = new XElement("OtherDetails", firstName , Nannyid, birth,Motherid);
            ChildRoot.Add(new XElement("Child", id, OtherDetails));
            ChildRoot.Save(ChildPath);
        }

        public void addContract(Contract c)
        {
            throw new NotImplementedException();
        }

        public void addMom(Mother m)
        {
            throw new NotImplementedException();
        }

        public void addNanny(Nanny n)
        {
            throw new NotImplementedException();
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
        }

        public void deleteContract(Contract c)
        {
            throw new NotImplementedException();
        }

        public void deleteMom(Mother m)
        {
            throw new NotImplementedException();
        }

        public void deleteNanny(Nanny n)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Child> GetAllChilds(Func<Child, bool> predicat = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Child> GetAllChildsByMother(Mother m)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Contract> GetAllContracts(Func<Contract, bool> predicat = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mother> GetAllMothers(Func<Mother, bool> predicat = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Nanny> GetAllNannies(Func<Nanny, bool> predicat = null)
        {
            throw new NotImplementedException();
        }

        public Child GetChild(int id)
        {
            throw new NotImplementedException();
        }

        public Contract GetContract(int cont)
        {
            throw new NotImplementedException();
        }

        public Mother GetMother(int id)
        {
            throw new NotImplementedException();
        }

        public Nanny GetNanny(int id)
        {
            throw new NotImplementedException();
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
        }

        public void updateContract(Contract c)
        {
            throw new NotImplementedException();
        }

        public void updateMom(Mother m)
        {
            throw new NotImplementedException();
        }

        public void updateNanny(Nanny n)
        {
            throw new NotImplementedException();
        }
    }
}
