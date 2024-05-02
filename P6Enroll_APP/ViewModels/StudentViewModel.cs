using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using P6Enroll_APP.Models;

namespace P6Enroll_APP.ViewModels {
    public class StudentViewModel {

        public P6Enroll_APP.Models.Student MyStudent { get; set; }

        public StudentViewModel() {
            MyStudent = new P6Enroll_APP.Models.Student();
        }

        public async Task<P6Enroll_APP.Models.Student> GetStudentByIdAsync(string studentID) {
            try {
                List<P6Enroll_APP.Models.Student>? roles = new List<P6Enroll_APP.Models.Student>();
                roles = await MyStudent.GetAllUserAsync();
                if (roles == null) {
                    return null;
                } else {
                    foreach (var item in roles) {
                        if (item.IdStudent == studentID) {
                            return item;
                        }
                    }
                    return null;
                }

            } catch (Exception) {

                throw;
            }
        }

        public async Task<List<P6Enroll_APP.Models.Student>> GetAllStudentsAsync() {
            try {
                List<P6Enroll_APP.Models.Student>? roles = new List<P6Enroll_APP.Models.Student>();
                roles = await MyStudent.GetAllUserAsync();
                if (roles == null) {
                    return null;
                } else {
                    return roles;
                }

            } catch (Exception) {
                throw;
            }
        }

        public async Task<bool> ModifyStudentAsync(P6Enroll_APP.Models.Student newStudent) {
            try {
                bool mofified = await MyStudent.ModifyStudentAsync(newStudent);
                return mofified;
            } catch (Exception) {
                throw;
            }
        }

        public async Task<bool> InsertStudentAsync(Student newStudent) {
            try {
                bool inserted = await MyStudent.InsertStudentAsync(newStudent);
                return inserted;
            } catch (Exception) {
                throw;
            }
        }


    }
}
