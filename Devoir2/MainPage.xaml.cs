using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ModelMetier;
using Windows.UI.Popups;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Devoir2
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Dictionary<string, List<ActionAchetee>> dico = new Dictionary<string, List<ActionAchetee>>();
        List<ActionReelle> lesActionsReelles = new List<ActionReelle>();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            
            #region jeu d'essais pour le dico

            dico.Add

            ("Enzo", new List<ActionAchetee>()

            {

new ActionAchetee()

{

CodeAction = "AAPL",

NomAction = "Apple",

ValeurAction = 200,

PrixAchat = 210,

Quantite = 10

},

new ActionAchetee()

{

CodeAction = "MSFT",

NomAction = "Microsoft",

ValeurAction = 140,

PrixAchat = 100,

Quantite = 50

},

new ActionAchetee()

{

CodeAction = "TWTR",

NomAction = "Twitter",

ValeurAction = 40,

PrixAchat = 35,

Quantite = 20

},

new ActionAchetee()

{

CodeAction = "IBM",

NomAction = "International Business Machines",

ValeurAction = 140,

PrixAchat = 110,

Quantite = 40

}

            }

            );

            dico.Add

            ("Noa", new List<ActionAchetee>()

            {

new ActionAchetee()

{

CodeAction = "FB",

NomAction = "Facebook",

ValeurAction = 180,

PrixAchat = 210,

Quantite = 10

},

new ActionAchetee()

{

CodeAction = "AXA",

NomAction = "Axa assurances",

ValeurAction = 25,

PrixAchat = 15,

Quantite = 20

},

new ActionAchetee()

{

CodeAction = "SAP",

NomAction = "SAP SE",

ValeurAction = 120,

PrixAchat = 100,

Quantite = 30

}

            }

            );

            dico.Add

            ("Lilou", new List<ActionAchetee>()

            {

new ActionAchetee()

{

CodeAction = "TWTR",

NomAction = "Twitter",

ValeurAction = 40,

PrixAchat = 25,

Quantite = 50

},

new ActionAchetee()

{

CodeAction = "INTC",

NomAction = "Intel Corporation",

ValeurAction = 50,

PrixAchat = 35,

Quantite = 15

},

new ActionAchetee()

{

CodeAction = "VMW",

NomAction = "VMware",

ValeurAction = 145,

PrixAchat = 150,

Quantite = 30

},

new ActionAchetee()

{

CodeAction = "TXN",

NomAction = "Texas Instrument Incorporated",

ValeurAction = 130,

PrixAchat = 140,

Quantite = 25

}

            }

            );

            #endregion
            #region jeu d'essais pour la liste de toutes les actions réelles

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "AAPL",

                NomAction = "Apple",

                ValeurAction = 200

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "MSFT",

                NomAction = "Microsoft",

                ValeurAction = 14

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "TWTR",

                NomAction = "Twitter",

                ValeurAction = 40

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "IBM",

                NomAction = "International Business Machines",

                ValeurAction = 140

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "FB",

                NomAction = "Facebook",

                ValeurAction = 180

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "AXA",

                NomAction = "Axa assurances",

                ValeurAction = 25

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "SAP",

                NomAction = "SAP SE",

                ValeurAction = 120

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "INTC",

                NomAction = "Intel Corporation",

                ValeurAction = 50

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "VMW",

                NomAction = "VMware",

                ValeurAction = 145

            }

            );

            lesActionsReelles.Add

            (

            new ActionReelle()

            {

                CodeAction = "TXN",

                NomAction = "Texas Instrument Incorporated",

                ValeurAction = 130

            }

            );

            #endregion
            lvTraders.ItemsSource = dico.Keys;
            lvActionReelles.ItemsSource = lesActionsReelles;
        }

        private void LvTraders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lvTraders.SelectedItem != null)
            {
                List<ActionAchetee> actionsAchetees = dico[lvTraders.SelectedItem.ToString()];
                lvActionAchetee.ItemsSource = actionsAchetees;
                double somme = 0;
                foreach(ActionAchetee a in actionsAchetees)
                {
                    somme += a.Quantite * a.PrixAchat;
                }

                txtPortefeuille.Text = somme.ToString();
            }
        }

        private async void BtnVendreAction_Click(object sender, RoutedEventArgs e)
        {
            if (lvActionAchetee.SelectedItem != null)
            {
                if(txtQuantiteVendue.Text != "")
                {

                    ActionAchetee a = lvActionAchetee.SelectedItem as ActionAchetee;
                    if(a.Quantite< Convert.ToInt32(txtQuantiteVendue.Text))
                    {
                        var dialog = new MessageDialog("Vous ne pouvez pas vendre au delas de ce que vous possédez");
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        int nouvelleQuantite = a.Quantite - Convert.ToInt32(txtQuantiteVendue.Text);
                        bool effacer;
                        if(nouvelleQuantite == 0)
                        {
                            dico[lvTraders.SelectedItem.ToString()].Remove(a);
                            txtPrixAchat.Text = "";
                            txtNomAction.Text = "";
                            txtQuantiteAchetee.Text = "";
                            txtValeurAction.Text = "";
                            txtQuantiteVendue.Text = "";
                            effacer = true;
                        }
                        else
                        {
                            effacer = false;
                            a.Quantite = nouvelleQuantite;
                            txtQuantiteAchetee.Text  = a.Quantite.ToString();
                            lvActionAchetee.SelectedItem = a;
                        }
                        List<ActionAchetee> actionsAchetees = dico[lvTraders.SelectedItem.ToString()];
                        lvActionAchetee.ItemsSource = null;
                        lvActionAchetee.ItemsSource = actionsAchetees;
                        if (effacer == false)
                        {
                            lvActionAchetee.SelectedItem = a;
                        }
                        double somme = 0;
                        foreach (ActionAchetee ab in actionsAchetees)
                        {
                            somme += ab.Quantite * ab.PrixAchat;
                        }

                        txtPortefeuille.Text = somme.ToString();

                        


                    }
                }
                else
                {
                    var dialog = new MessageDialog("Saisir la quantité vendue");
                    await dialog.ShowAsync();
                }
            }
            else
            {
                var dialog = new MessageDialog("Selectionnez une action");
                await dialog.ShowAsync();
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if(lvActionReelles.SelectedItem != null)
            {
                if(txtPrixAchatAction.Text != null)
                {
                    if (txtQuantiteeAction.Text != null) 
                    {
                        ActionReelle laction = lvActionReelles.SelectedItem as ActionReelle;

                        ActionAchetee achatAction = new ActionAchetee()
                        {
                            Quantite = Convert.ToInt32(txtQuantiteeAction.Text),
                            PrixAchat = Convert.ToDouble(txtPrixAchatAction.Text),
                            CodeAction = laction.CodeAction,
                            NomAction = laction.NomAction,
                            ValeurAction = laction.ValeurAction

                        };
                        dico[lvTraders.SelectedItem.ToString()].Add(achatAction);
                        lvActionAchetee.ItemsSource = null;
                        lvActionAchetee.ItemsSource = dico[lvTraders.SelectedItem.ToString()];

                        List<ActionAchetee> actionsAchetees = dico[lvTraders.SelectedItem.ToString()];
                        double somme = 0;
                        foreach (ActionAchetee a in actionsAchetees)
                        {
                            somme += a.Quantite * a.PrixAchat;
                        }

                        txtPortefeuille.Text = somme.ToString();


                    }
                    else
                    {
                        var dialog = new MessageDialog("Saisir la quantité d'actions");
                        await dialog.ShowAsync();
                    }
                }
                else
                {
                    var dialog = new MessageDialog("Saisir le prix d'achat");
                    await dialog.ShowAsync();
                }

            }
            else
            {
                var dialog = new MessageDialog("Selectionnez une action");
                await dialog.ShowAsync();
            }
        }

        private void LvActionAchetee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lvActionAchetee.SelectedItem != null)
            {
                ActionAchetee laction = lvActionAchetee.SelectedItem as ActionAchetee;
                txtNomAction.Text = laction.NomAction.ToString();
                txtValeurAction.Text = laction.ValeurAction.ToString();
                txtPrixAchat.Text = laction.PrixAchat.ToString();
                txtQuantiteAchetee.Text = laction.Quantite.ToString();
            }

        }
    }
}
