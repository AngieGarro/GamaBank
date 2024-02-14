using AppCore_Logic;
using AppCore_Logic.Managers;
using POJOS_DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroFrameworkUI
{
    public partial class FormLogic : Form
    {
        public FormLogic()
        {
            InitializeComponent();
        }

        //CRUD CUSTOMER
        private void btnSearchC_Click(object sender, EventArgs e)
        {
            var cm = new CustomerManager();

            var id = text_IdCus.Text;

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Debe completar el campo ID");
            }
            else
            {
                var customer = cm.RetrieveById(id);
                if (customer != null)
                {
                    text_NameCus.Text = customer.Name;
                    text_LastCus.Text = customer.LastName;
                    text_emailCus.Text = customer.Email;
                    text_PhoneCus.Text = customer.Phone;
                }
                else
                {
                    MessageBox.Show("Cliente no existe.");
                }
            }
        }

        private void btnSaveC_Click(object sender, EventArgs e)
        {
            var cm = new CustomerManager();

            //Validar que todos los campos esten completos.
            var customer = new Customer()
            {
                Id = text_IdCus.Text,
                Name = text_NameCus.Text,
                LastName = text_LastCus.Text,
                Email = text_emailCus.Text,
                Phone = text_PhoneCus.Text
            };

            cm.Create(customer);
            MessageBox.Show("Cliente creado correctamente");
        }

        private void btnUpdC_Click(object sender, EventArgs e)
        {
            var cm = new CustomerManager();

            //Validar que todos los campos esten completos.
            var customer = new Customer()
            {
                Id = text_IdCus.Text,
                Name = text_NameCus.Text,
                LastName = text_LastCus.Text,
                Email = text_emailCus.Text,
                Phone = text_PhoneCus.Text
            };

            cm.UpdateCustomer(customer);
            MessageBox.Show("Cliente actualizado correctamente");

        }

        private void btnDeletC_Click(object sender, EventArgs e)
        {
            var cm = new CustomerManager();

            var id = text_IdCus.Text;

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Debe completar el campo ID");
            }
            else
            {
                cm.DeleteCustomer(id);
                MessageBox.Show("Cliente eliminado.");
            }
        }

        //CRUD COINS

        private void btnSearchCoin_Click(object sender, EventArgs e)
        {
            var cm = new CoinsManager();

            var id = textIdC.Text;

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Debe completar el campo ID");
            }
            else
            {
                var coins = cm.RetrieveById(id);
                if (coins != null)
                {
                    textNameC.Text = coins.Name;
                    textFCodC.Text = coins.FintechCode;
                    textPriceC.Text = coins.ExchangePrice;
                    
                }
                else
                {
                    MessageBox.Show("Coin no existe.");
                }
            }

        }

        private void btnSaveCoin_Click(object sender, EventArgs e)
        {
            var cm = new CoinsManager();

            //Validar que todos los campos esten completos.
            var coins = new Coins()
            {
                Id = textIdC.Text,
                Name = textNameC.Text,
                FintechCode = textFCodC.Text,
                ExchangePrice = textPriceC.Text
            };

            cm.Create(coins);
            MessageBox.Show("Coin creado correctamente");
        }

        private void btnUpdCoin_Click(object sender, EventArgs e)
        {
            var cm = new CoinsManager();

            //Validar que todos los campos esten completos.
            var coins = new Coins()
            {
                Id = textIdC.Text,
                Name = textNameC.Text,
                FintechCode = textFCodC.Text,
                ExchangePrice = textPriceC.Text
            };

            cm.UpdateCoins(coins);
            MessageBox.Show("Coin Actualizado correctamente");

        }

        private void btnDeletCoin_Click(object sender, EventArgs e)
        {
            var cm = new CoinsManager();

            var id = textIdC.Text;

            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("Debe completar el campo ID");
            }
            else
            {
                cm.DeleteCoins(id);
                MessageBox.Show("Coin eliminado.");
            }
        }


        //CRUD ACCOUNT
        private void btnSearchAcc_Click(object sender, EventArgs e)
        {
            var cm = new AccountManager();

            var UBAN = textUBAN.Text;

            if (string.IsNullOrEmpty(UBAN))
            {
                MessageBox.Show("Debe completar el campo UBAN");
            }
            else
            {
                var account = cm.RetrieveById(UBAN);
                if (account != null)
                {
                    textUBAN.Text = account.UBAN;
                    textAccountN.Text = account.AccountName;
                    textCustId.Text = account.CustomerId;
                    textCoinC.Text = account.CoinCode;
                    textStatus.Text = account.Status;
                

                }
                else
                {
                    MessageBox.Show("Cuenta no existe.");
                }
            }

        }

        private void btnSaveAcc_Click(object sender, EventArgs e)
        {
            var cm = new AccountManager();

            //Validar que todos los campos esten completos.
            var account = new Account()
            {
                UBAN = textUBAN.Text,
                AccountName = textAccountN.Text,
                CustomerId = textCustId.Text,
                CoinCode = textCoinC.Text,
                Status = textStatus.Text
            };

            cm.Create(account);
            MessageBox.Show("Cuenta creada correctamente");

        }

        private void btnUpdAcc_Click(object sender, EventArgs e)
        {
            var cm = new AccountManager();

            //Validar que todos los campos esten completos.
            var account = new Account()
            {
                UBAN = textUBAN.Text,
                AccountName = textAccountN.Text,
                CustomerId = textCustId.Text,
                CoinCode = textCoinC.Text,
                Status = textStatus.Text
            };

            cm.UpdateAccount(account);
            MessageBox.Show("Cuenta actualizada correctamente");

        }

        private void btnDeletAcc_Click(object sender, EventArgs e)
        {
            var cm = new AccountManager();

            var UBAN = textUBAN.Text;

            if (string.IsNullOrEmpty(UBAN))
            {
                MessageBox.Show("Debe completar el campo UBAN");
            }
            else
            {
                cm.DeleteAccount(UBAN);
                MessageBox.Show("Cuenta eliminada.");
            }
        }

        //TRANSACTION
        private void btnCreateTransact_Click(object sender, EventArgs e)
        {
            var cm = new TransactionManager();

            //Validar que todos los campos esten completos.
            var trans = new Transaction()
            {
                Id = textIdTrans.Text,
                AccountUBAN = textAccTrans.Text,
                FintechUBAN = textAccFint.Text,
                Type= textAccType.Text,
                Amount = textAmount.Text
            };

            cm.Create(trans);
            MessageBox.Show("Transaccion efectuada correctamente");
        }

      
    }
}
