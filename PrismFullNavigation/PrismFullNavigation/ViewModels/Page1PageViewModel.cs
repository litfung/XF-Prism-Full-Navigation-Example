﻿using Prism.Commands;
using Prism.Navigation;

namespace PrismFullNavigation.ViewModels
{
    public class Page1PageViewModel : BaseViewModel
    {
        public bool ButtonIsEnable { get; set; }

        string _name;
        public string Name
        {
            get
            {
                return _name;

            }
            set
            {
                SetProperty(ref _name, value, "Name");
                UpdateButtonStatus();
            }
        }


        public DelegateCommand SendCommandClick { get; set; }


        public Page1PageViewModel(INavigationService navigationService) : base(navigationService)
        {
            TitlePage = "Page1";


            SendCommandClick = new DelegateCommand(async delegate
            {
                //Set parameters to Send
                var navParameters = new NavigationParameters();
                navParameters.Add("name", Name);

                //Navigate to Page2Page
                var result = await NavigationService.NavigateAsync("Page2Page", navParameters);


            },
           delegate
           {
               return ButtonIsEnable == true ? true : false;

           }).ObservesProperty(() => ButtonIsEnable);
        }

 

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);

            //Return data parameters from Page2Page
            if (parameters.ContainsKey("name"))
            {
                Name = parameters["name"] as string;
            }
        }

   

        private void UpdateButtonStatus()
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                ButtonIsEnable = true;
            }
            else
            {
                ButtonIsEnable = false;

            }
        }
    }
}
