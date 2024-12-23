using api.DTO;
using api.DTO.Admins;
using api.Model;

namespace api.Mappers{
    // The purpose of this is to remove unwanted data in some situvation.
    public static class AdminMapper{   // extention methodes needs to have static keyword
    public static AdminDTO ToAdminDto(this Admin adminInstance){  // here AdminDTO is a return type of object
    // this.admin => It tells the compiler that this method is designed to work with objects of type Admin (database model).
    // adminInstance => It represents the instance of the Admin class that you want to convert into an AdminDTO.
        return new AdminDTO{
        adminName=adminInstance.adminName,
    };
}



    public static Admin ToAdminFromCreateDto(this CreateAdminDtoRequest adminInstance){
        return  new Admin{
                 adminName = adminInstance.adminName,
                password = adminInstance.password,
        };
    }



    }
}