using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* ******************************************************
* CIS 123: Introduction to Object-Oriented Programming  *
* Murach C# 7th ed, Chapter 6: How to code methods      *
*                and event handlers                     *
* Exercise 6-3 Enhance the Invoice Total Application    *
*       Base code and form design provided by Murach    *
*       Exercise Instructions: pg. 192                  *
* Dominique Tepper, 05MAY2022                           *
* ******************************************************/

namespace InvoiceTotal
{
    public partial class frmInvoiceTotal : Form
    {
        public frmInvoiceTotal()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string customerType = txtCustomerType.Text;
            decimal subtotal = Convert.ToDecimal(txtSubtotal.Text);
            //decimal discountAmount = subtotal * discountPercent;

/* *****************************************************************************************************************
 *  5-A. Modify the calling code so it deconstructs the tuple that's returned by the GetInvoicesAmounts() method.  *
 *  5-B. Once modified, delete the statements that declare and calculate the discount amount and invoice total     *
 * ****************************************************************************************************************/
            (decimal discountAmount, decimal discountPercent, decimal invoiceTotal) = 
                this.GetInvoicesAmounts(customerType, subtotal, discountPercent); // 5-A

            txtDiscountPercent.Text = discountPercent.ToString("p1");
            txtDiscountAmount.Text = discountAmount.ToString("c");
            txtTotal.Text = invoiceTotal.ToString("c");

            txtCustomerType.Focus();
        }

/* ******************************************************************************************
* 4-A. Modify the declaration for the GetInvoiceAmounts() method so it returns a tuple that *
*    includes the discount percent and the discount amount.                                 *
* ******************************************************************************************/
        //private static decimal GetInvoicesAmounts(string customerType, decimal subtotal, decimal discountPercent)
        private (decimal discountAmount, decimal discountPercent, decimal invoiceTotal) 
            GetInvoicesAmounts(string customerType, decimal subtotal, decimal InvoiceTotal)
        {
            decimal discountPercent = .0m; 
            decimal discountAmount = subtotal * discountPercent;
            decimal invoiceTotal = subtotal - discountAmount;

            if (customerType == "R")
            {
                if (subtotal < 100)
                    discountPercent = .0m;
                else if (subtotal >= 100 && subtotal < 250)
                    discountPercent = .1m;
                else if (subtotal >= 250)
                    discountPercent = .25m;
            }
            else if (customerType == "C")
            {
                if (subtotal < 250)
                    discountPercent = .2m;
                else
                    discountPercent = .3m;
            }
            else
            {
                discountPercent = .4m;
            }

            return (discountAmount, discountPercent, invoiceTotal);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
