using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Microsoft.Maui.Devices.Sensors;
using P6Enroll_APP.Models;

namespace P6Enroll_APP.ViewModels
{
    public class ProfessorViewModel : BaseViewModel
    {

        public P6Enroll_APP.Models.Professor MyProfessor { get; set; }

        public ProfessorViewModel()
        {
            MyProfessor = new P6Enroll_APP.Models.Professor();
        }

        public async Task<P6Enroll_APP.Models.Professor> GetUserByProfessorIDAsync(string professorID)
        {
            try
            {
                List<P6Enroll_APP.Models.Professor>? roles = new List<P6Enroll_APP.Models.Professor>();
                roles = await MyProfessor.GetAllUsersAsync();
                if (roles == null)
                {
                    return null;
                }
                else
                {
                    foreach (var item in roles)
                    {
                        if (item.IdProfessor == professorID)
                        {
                            return item;
                        }
                    }
                    return null;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<P6Enroll_APP.Models.Professor>> GetAllUsersAsync()
        {
            try
            {
                List<P6Enroll_APP.Models.Professor>? roles = new List<P6Enroll_APP.Models.Professor>();
                roles = await MyProfessor.GetAllUsersAsync();
                if (roles == null)
                {
                    return null;
                }
                else
                {
                    return roles;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> modifyProfessorAsync(P6Enroll_APP.Models.Professor newProfessor)
        {
            try
            {
                bool modified = await MyProfessor.modifyProfessorAsync(newProfessor);
                return modified;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> insertProfessorAsync(P6Enroll_APP.Models.Professor newProfessor)
        {
            try
            {
                bool updated = await MyProfessor.insertProfessorAsync(newProfessor);
                return updated;

            }
            catch (Exception)
            {
                throw;
            }
        }




        //Cierre de public 
    }
}
