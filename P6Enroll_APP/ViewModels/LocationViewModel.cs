using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P6Enroll_APP.Models;

namespace P6Enroll_APP.ViewModels {
    public class LocationViewModel : BaseViewModel {

        public P6Enroll_APP.Models.Location MyUser { get; set; }

        public LocationViewModel() {
            MyUser = new P6Enroll_APP.Models.Location();
        }

        public async Task<P6Enroll_APP.Models.Location> GetUserByLocationIDAsync(string locationID) {
            try {
                List<P6Enroll_APP.Models.Location>? roles = new List<P6Enroll_APP.Models.Location>();
                roles = await MyUser.GetAllUsersAsync();
                if (roles == null) {
                    return null;
                } else {
                    foreach (var item in roles) {
                        if (item.IdLocation == locationID) {
                            return item;
                        }
                    }
                    return null;
                }

            } catch (Exception) {

                throw;
            }
        }

        public async Task<List<P6Enroll_APP.Models.Location>> GetAllUsersAsync() {
            try {
                List<P6Enroll_APP.Models.Location>? roles = new List<P6Enroll_APP.Models.Location>();
                roles = await MyUser.GetAllUsersAsync();
                if (roles == null) {
                    return null;
                } else {
                    return roles;
                }

            } catch (Exception) {

                throw;
            }
        }
    }
}
