using api.DTO;
using api.Model;

namespace api.Mappers{


    // The purpose of this is to remove unwanted data in some situvation.
    public static class AdminMapper{   // extention methodes needs to have static keyword
public static AdminDTO ToAdminDto(this Admin Admin){
    return new AdminDTO{
    adminName=Admin.adminName,
    };
}



public static Admin ToAdmin
    }
}