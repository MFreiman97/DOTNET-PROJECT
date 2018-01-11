using BE;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_UI
{
    /// <summary>
    /// Interaction logic for SmallWindowUpdating.xaml
    /// </summary>
    public partial class SmallWindowUpdating : MetroWindow
    {
        Child c;
        Nanny n;
        Contract co;
        Mother m;
        BL.IBL bl;
        public SmallWindowUpdating(object obj)
        {
           
            InitializeComponent();
            AllowEditingCB.IsChecked = false;
            AllowEditingCBMother.IsChecked = false;
            AllowEditing.Text = "";
            bl = BL.FactoryBL.GetBL();
            if (obj is Child)
            {
                WhatToShowTB.Text = "Child";

                Child c = obj as Child;
                DetailsOfChild.DataContext = c;
             
              
            }
            if (obj is Mother)
            {
                WhatToShowTB.Text = "Mother";
                Mother m = obj as Mother;
                DetailsOfMother.DataContext = m;
                if(bl.GetNumOfContracts(m)==0)
                {

                    AllowEditing.Text = "True";
                    AllowEditingCBMother.IsChecked = true;
                    AllowEditingCB.IsChecked =false ;
                    MatrixMother.ValueTimes = m.timeWork;
                    MatrixMother.ValueBool = m.needNanny;
                }

            }
            if (obj is Nanny)
            {
                WhatToShowTB.Text = "Nanny";//using the trigger
                Nanny n = obj as Nanny;
                DetailsOfNanny.DataContext = n;

                if (bl.GetNumOfContracts(n) == 0)
                {
                    AllowEditing.Text = "True";
                    AllowEditingCB.IsChecked = true;
                    AllowEditingCBMother.IsChecked = false;
                    MatrixNanny.ValueTimes =n.schedule;
                    MatrixNanny.ValueBool = n.DaysOfWork;
                 
                    
                }
            }
            if (obj is Contract)
            {
                WhatToShowTB.Text = "Contract";//using the trigger
                Contract co = obj as Contract;
               DetailsOfContract.DataContext = co;
            }
            
        }


    

      
    }

}
