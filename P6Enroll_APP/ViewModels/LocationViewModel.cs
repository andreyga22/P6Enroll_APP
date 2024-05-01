using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Devices.Sensors;
using P6Enroll_APP.Models;

namespace P6Enroll_APP.ViewModels {
    public class LocationViewModel : BaseViewModel {

        public P6Enroll_APP.Models.Location MyLocation { get; set; }

        public LocationViewModel() {
            MyLocation = new P6Enroll_APP.Models.Location();
        }

        public async Task<P6Enroll_APP.Models.Location> GetUserByLocationIDAsync(string locationID) {
            try {
                List<P6Enroll_APP.Models.Location>? roles = new List<P6Enroll_APP.Models.Location>();
                roles = await MyLocation.GetAllUsersAsync();
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
                roles = await MyLocation.GetAllUsersAsync();
                if (roles == null) {
                    return null;
                } else {
                    return roles;
                }

            } catch (Exception) {
                throw;
            }
        }

        public async Task<bool> modifyLocationAsync(P6Enroll_APP.Models.Location newLocation) {
            try {
                bool modified = await MyLocation.modifyLocationAsync(newLocation);
                return modified;

            } catch (Exception) {
                throw;
            }
        }

        public async Task<bool> insertLocationAsync(P6Enroll_APP.Models.Location newLocation) {
            try {
                bool updated = await MyLocation.insertLocationAsync(newLocation);
                return updated;

            } catch (Exception) {
                throw;
            }
        }
    }
}
