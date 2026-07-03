using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PizzaOrderSystem
{
    public partial class frmPizzaOrderSystem : Form
    {
        public frmPizzaOrderSystem()
        {
            InitializeComponent();
        }

        
        void UpdateSize()
        {
            UpdateTotalPrice();

            if (rbSmall.Checked)
            {
                lblSize.Text = "Small";
                return;
            }
            if (rbMeduim.Checked)
            {
                lblSize.Text = "Meduim";
                return;
            }
            if (rbLarge.Checked)
            {
                lblSize.Text = "Large";
                return;
            }

        }
        void UpdateCrust()
        {
            UpdateTotalPrice();
            if (rbThinCrust.Checked)
            {
                lblCrustType.Text = "Thin Crust";
                return;
            }
            else if(rbThickCrust.Checked)
            {
                lblCrustType.Text = "Thick Crust";
                return;
            }

        }
        void UpdateToppings()
        {
            UpdateTotalPrice();
            string sToppings = "";

            if (chkExtraChess.Checked)
            {
                sToppings += "Extra Chees";
            }

            if (chkOnion.Checked)
            {
                sToppings += ", Onion";
            }

            if (chkMushrooms.Checked)
            {
                sToppings += ", Mushrooms";
            }

            if (chkOlives.Checked)
            {
                sToppings += ", Olives";
            }

            if (chkTomatoes.Checked)
            {
                sToppings += ", Tomatoes";
            }

            if (chkGreenPeppers.Checked)
            {
                sToppings += ", Green Peppers";
            }

            if (sToppings.StartsWith(","))
            {
                sToppings = sToppings.Substring(1,sToppings.Length-1).Trim();
            }

            if (sToppings == "")
                sToppings = "No Toppings";

            lblToppings.Text = sToppings;
        }

        void UpdateWhereToEat()
        {
            if (rbEatIn.Checked)
            {
                lblWhereToEat.Text = "Eat In";
                return;
            }
            else if (rbTakeOut.Checked)
            {
                lblWhereToEat.Text = "Take Out";
                return;
            }
        }
        void UpdateOrderSummary()
        {
            UpdateSize();
            UpdateToppings();
            UpdateCrust();
            UpdateWhereToEat();
            UpdateTotalPrice();
        }
        void ResetForm()
        {
            gbSize.Enabled = true;
            gbTopping.Enabled = true;
            gbWhereToEat.Enabled = true;
            gbCrustType.Enabled = true;

            rbMeduim.Checked = true;

            chkExtraChess.Checked = false;
            chkGreenPeppers.Checked = false;
            chkOlives.Checked = false;
            chkTomatoes.Checked = false;
            chkMushrooms.Checked = false;
            chkOnion.Checked = false;

            rbThinCrust.Checked = true;

            rbEatIn.Checked = true;

            btnOrderPizza.Enabled = true;
        }
        float GetSelectedSizePrice()
        {
            if (rbSmall.Checked)
            
                return Convert.ToSingle(rbSmall.Tag);
            
            else if (rbLarge.Checked)
            
                return Convert.ToSingle(rbLarge.Tag);
            
            else
            
                return Convert.ToSingle(rbMeduim.Tag);
            
        }

        float CalculateToppingsPrice()
        {
            float ToppingsTotalPrice = 0;

            if (chkExtraChess.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkExtraChess.Tag);    
            }
            if (chkGreenPeppers.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkGreenPeppers.Tag);
            }
            if (chkMushrooms.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkMushrooms.Tag);
            }
            if (chkOlives.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOlives.Tag);
            }
            if (chkTomatoes.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkTomatoes.Tag);
            }
            if (chkOnion.Checked)
            {
                ToppingsTotalPrice += Convert.ToSingle(chkOnion.Tag);
            }

            return ToppingsTotalPrice;
        }
        float GetSelectedCrustPrice()
        {
            if (rbThinCrust.Checked)
            
                return Convert.ToSingle(rbThinCrust.Tag);
            
            else           
                return Convert.ToSingle(rbThickCrust.Tag);
            

        }
        float CalculateTotalPrice()
        {
            return GetSelectedCrustPrice() + GetSelectedSizePrice() + CalculateToppingsPrice();
        }
        void UpdateTotalPrice()
        {
            lblTotalPrice.Text = "$" + CalculateTotalPrice().ToString();
        }

        private void rbSmall_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbMeduim_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbLarge_CheckedChanged(object sender, EventArgs e)
        {
            UpdateSize();
        }

        private void rbThinCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbThickCrust_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCrust();
        }

        private void rbEatIn_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = rbEatIn.Text;
            CalculateTotalPrice();

        }

        private void rbTakeOut_CheckedChanged(object sender, EventArgs e)
        {
            lblWhereToEat.Text = rbTakeOut.Text;
            CalculateTotalPrice();

        }

        private void chkExtraChess_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();

        }

        private void chkOnion_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkMushrooms_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkTomatoes_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkGreenPeppers_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void chkOlives_CheckedChanged(object sender, EventArgs e)
        {
            UpdateToppings();
        }

        private void btnOrderPizza_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirm Order","Confirm",MessageBoxButtons.OKCancel
                ,MessageBoxIcon.Question)==DialogResult.OK)
            {
                MessageBox.Show("Order Placed Successfully", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnOrderPizza.Enabled = false;
                gbSize.Enabled = false;
                gbTopping.Enabled = false;
                gbWhereToEat.Enabled = false;
                gbCrustType.Enabled = false;
            }           
        }

        private void btnResetForm_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void frmPizzaProject_Load(object sender, EventArgs e)
        {
            UpdateOrderSummary();
        }
    }
}
