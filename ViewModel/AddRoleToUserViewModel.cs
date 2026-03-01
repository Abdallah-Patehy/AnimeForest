namespace Anime_Forest.ViewModel
{
    public class AddRoleToUserViewModel
    {
        public string UserName { get; set; }
        public string RoleName { get; set; }
    }
}


//@model Anime_Forest.ViewModel.AddRoleToUserViewModel

//@{
//    ViewData["Title"] = "Assign Role to User";
//}

//< div class= "container mt-5" >
//    < div class= "row justify-content-center" >
//        < div class= "col-md-6" >
//            < div class= "card shadow-lg bg-dark text-white border-info" >
//                < div class= "card-header bg-info text-dark" >
//                    < h4 class= "mb-0" > Assign Role to User</h4>
//                </div>
//                <div class= "card-body" >
//                    < form asp - action = "SaveAddRoleToUser" method = "post" >
//                        < div asp - validation - summary = "All" class= "text-danger" ></ div >

//                        < div class= "mb-3" >
//                            < label class= "form-label fw-bold" > Select User </ label >
//                            < select asp -for= "UserId" class= "form-select"
//                                    asp - items = "@(new SelectList(ViewBag.Users, "Id", "UserName"))">
//                                <option value="">-- Choose User --</option>
//                            </select>
//                        </div>

//                        <div class= "mb-4" >
//                            < label class= "form-label fw-bold" > Select Role </ label >
//                            < select asp -for= "RoleName" class= "form-select"
//                                    asp - items = "@(new SelectList(ViewBag.Roles, "Name", "Name"))">
//                                <option value="">-- Choose Role --</option>
//                            </select>
//                        </div>

//                        <div class= "d-grid gap-2" >
//                            < button type = "submit" class= "btn btn-info fw-bold" > Assign Role </ button >
//                            < a asp - action = "Index" class= "btn btn-outline-light" > Back </ a >
//                        </ div >
//                    </ form >
//                </ div >
//            </ div >
//        </ div >
//    </ div >
//</ div >