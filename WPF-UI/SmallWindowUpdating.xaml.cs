using BE;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
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
        object MyObj;
      
        private List<string> errorMessages;
        public SmallWindowUpdating(object obj)
        {

            InitializeComponent();
            MyObj = obj;
      
            AllowEditingCB.IsChecked = false;
            AllowEditingCBMother.IsChecked = false;
            AllowEditing.Text = "";
            bl = BL.FactoryBL.GetBL();
            errorMessages = new List<string>();
            if (obj is Child)
            {
                WhatToShowTB.Text = "Child";
                 c = new Child();
                c = obj as Child;
                DetailsOfChild.DataContext = c;
                if (c.nannyID != null)
                {
                    birthDatePicker.IsEnabled = false;
                }


            }
            if (obj is Mother)
            {
                WhatToShowTB.Text = "Mother";
                m = new Mother();
              m = obj as Mother;
                DetailsOfMother.DataContext = m;
                if (bl.GetNumOfContracts(m) == 0)
                {

                    AllowEditing.Text = "True";
                    AllowEditingCBMother.IsChecked = true;
                    AllowEditingCB.IsChecked = false;
                    MatrixMother.ValueTimes = m.timeWork;
                    MatrixMother.ValueBool = m.needNanny;
                }

            }
            if (obj is Nanny)
            {
                WhatToShowTB.Text = "Nanny";//using the trigger
                n = new Nanny();
                 n = obj as Nanny;
                DetailsOfNanny.DataContext = n;

                if (bl.GetNumOfContracts(n) == 0)
                {
                    AllowEditing.Text = "True";
                    AllowEditingCB.IsChecked = true;
                    AllowEditingCBMother.IsChecked = false;
                    MatrixNanny.ValueTimes = n.schedule;
                    MatrixNanny.ValueBool = n.DaysOfWork;


                }
            }
            if (obj is Contract)
            {
                WhatToShowTB.Text = "Contract";//using the trigger
                co = new Contract();
                 co = obj as Contract;
                DetailsOfContract.DataContext = co;
            }

        }

        private void validation_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                errorMessages.Add(e.Error.Exception.Message);
            else
                errorMessages.Remove(e.Error.Exception.Message);
        }

        private async void UpdateButtonContract_Click(object sender, RoutedEventArgs e)
        {
            if (errorMessages.Any())
            {
                string err = "";
                foreach (var item in errorMessages)
                    err += "\n" + item;
                var Message = await this.ShowMessageAsync("There is some ERRORS", err);
                if (Message == MessageDialogResult.Affirmative)
                    return;
            }
            else
            {
                if (WhatToShowTB.Text == "Child")
                {
                  
                    bl.updateChild(c);

                }
                if (WhatToShowTB.Text == "Mother")
                {
             
                    bl.updateMom(m);

                }
                if (WhatToShowTB.Text == "Nanny")
                {
                
                    bl.updateNanny(n);

                }
             
                var Message = await this.ShowMessageAsync("New Update was succeed", "Good Day");
                if (Message == MessageDialogResult.Affirmative)
                {


                    this.Close();

                }
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}