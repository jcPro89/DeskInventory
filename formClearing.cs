using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jcDeskInventory
{
    internal class formClearing
    {
        public static void ClearFormControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                switch (control)
                {
                    case TextBox:
                        TextBox txt = (TextBox)control;
                        txt.Text = string.Empty;
                        break;
                    
                    case ComboBox:
                        ComboBox cmb = (ComboBox)control;   
                        cmb.SelectedIndex = 0;
                        break;
                    
                    case CheckBox:
                        CheckBox chk = (CheckBox)control;
                        chk.Checked = true;
                        break;

                    case DateTimePicker:
                        DateTimePicker dtp = (DateTimePicker)control; 
                        dtp.Value = DateTime.Now;
                        break;

                    case RadioButton:
                        RadioButton radio = (RadioButton)control;   
                        radio.Checked = true;
                        break ;
                    case NumericUpDown:
                        NumericUpDown upd = (NumericUpDown)control;
                        upd.Value= 0;
                        break;
                }



                //if (control is TextBox)
                //{
                //    TextBox txt = (TextBox)control;
                //    txt.Text = string.Empty;
                //}
                //else if (control is CheckBox)
                //{
                //    CheckBox chk = (CheckBox)control;
                //    chk.Checked = false;
                //}
                //else if (control is RadioButton)
                //{
                //    RadioButton rdb = (RadioButton)control;
                //    rdb.Checked = false;
                //}
                //else if (control is DateTimePicker)
                //{
                //    DateTimePicker dtp = (DateTimePicker)control;
                //    dtp.Value = DateTime.Now;
                //}
            }
        
    }
}
}
