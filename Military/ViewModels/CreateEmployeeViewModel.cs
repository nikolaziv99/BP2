﻿using Military.Database;
using Military.Models;
using Military.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Military.ViewModels
{
    public class CreateEmployeeViewModel : INotifyPropertyChanged
    {
        private Visibility soldierFieldsVisible;
        private Visibility medicFieldsVisible;
        private EmployeeTypeModel type;
        private MilitaryPersonTypeModel militaryType;
        private string jmbgText;
        private string name;
        private string surname;
        private string licenseNo;
        private List<Rank> soldierRanks;
        private Rank soldierRanksSelected;
        MilitaryContainer mc = new MilitaryContainer();
        public Action CloseAction { get; set; }
        public CreateEmployeeViewModel()
        {
        }

        public CreateEmployeeViewModel(EmployeeTypeModel empType, MilitaryPersonTypeModel milType)
        {
            type = empType;
            militaryType = milType;
            SetFields(type, militaryType);
            SoldierRanks = populateRanks();

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public Visibility SoldierFieldsVisible
        {
            get { return soldierFieldsVisible; }
            set
            {
                if (soldierFieldsVisible != value)
                {
                    soldierFieldsVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Visibility MedicFieldsVisible
        {
            get { return medicFieldsVisible; }
            set
            {
                if (medicFieldsVisible != value)
                {
                    medicFieldsVisible = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                if (surname != value)
                {
                    surname = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string JMBGText
        {
            get { return jmbgText; }
            set
            {
                if (jmbgText != value)
                {
                    jmbgText = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public string LicenseNo
        {
            get { return licenseNo; }
            set
            {
                if (licenseNo != value)
                {
                    licenseNo = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public List<Rank> SoldierRanks
        {
            get { return soldierRanks; }
            set
            {
                if (soldierRanks != value)
                {
                    soldierRanks = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Rank SoldierRanksSelected
        {
            get { return soldierRanksSelected; }
            set
            {
                if (soldierRanksSelected != value)
                {
                    soldierRanksSelected = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private void SetFields(EmployeeTypeModel type, MilitaryPersonTypeModel MilitaryType)
        {
            if(type.ID == 1)
            {
                SoldierFieldsVisible = Visibility.Hidden;
                MedicFieldsVisible = Visibility.Hidden;
            } else
            {
                if (MilitaryType.ID == 0)
                {
                    SoldierFieldsVisible = Visibility.Visible;
                    MedicFieldsVisible = Visibility.Hidden;
                }
                else
                {
                    SoldierFieldsVisible = Visibility.Hidden;
                    MedicFieldsVisible = Visibility.Visible;
                }
            }
            
        }

        public ICommand CreateEmployeeCommand { get { return new RelayCommand(createEmployee, canCreateEmployee); } }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void createEmployee(object param)
        {
            if (!string.IsNullOrEmpty(JMBGText) && !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname))
            {
                if (mc.Employees.Select(x => x.JMBG).Contains(JMBGText))
                {
                    return;
                }
                if (type.ID == 1)
                {
                    mc.Employees.Add(new SupportPerson { Name = Name, Surname = Surname, JMBG = JMBGText });
                }
                else
                {
                    if (militaryType.ID == 0 && SoldierRanksSelected != null)
                    {

                        mc.Employees.Add(new Soldier
                        {
                            Name = Name,
                            Surname = Surname,
                            JMBG = JMBGText,
                            Rank = mc.Ranks.FirstOrDefault(x => x.Name == SoldierRanksSelected.Name),
                            CampId = 3
                        });

                    } else if(militaryType.ID == 1 && LicenseNo != null)
                    {
                        mc.Employees.Add(new Medic
                        {
                            Name = Name,
                            Surname = Surname,
                            JMBG = JMBGText,
                            LicenseNo = LicenseNo,
                            CampId = 3
                        });
                    }
                }
                mc.SaveChanges();
                CloseAction();
            } else
            {
                return;
            }
            
        }

        private bool canCreateEmployee(object param)
        {
            return true;
        }

        private List<Rank> populateRanks()
        {
            var ranks = new List<Rank>();

            ranks = mc.Ranks.ToList();

            return ranks;
        }

    }
}
