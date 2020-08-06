using AZCore.Database;
using AZCore.Database.SQL;
using AZCore.Domain;
using AZCore.Extensions;
using AZWeb.Module.Common;
using System;
using System.Data;
using JobVina.Data.Entities;
namespace JobVina.Data
{
    static class TestExtend
    {
        public static T DoAction<T>(this T model, Action<T> action)
        {
            if (action != null) action(model);
            return model;
        }
    }
    public class DBCreateEntities : EntityService
    {
        bool isDropTable;
        public DBCreateEntities(IDatabaseCore databaseCore,bool isDropTable) : base(databaseCore)
        {
            this.isDropTable = isDropTable;
        }

        public void CheckEmptyAndCreateDatabase()
        {
        //    this.BeginTransaction();
            
            if (this.isDropTable) {
                foreach (var item in this.GetType().GetTypeFromInterface<IEntity>())
                {
                    if (!item.IsTypeFromInterface<IModule>())
                    {
                        try
                        {
                            Execute(BuildSQL.NewSQL(item).DropTable());
                            Execute(BuildSQL.NewSQL(item).CreateTableIfNotExit());
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.Message);
                        }
                    }
                }
                CreateDataTentaint();
                CreateLocation();
            }
          //  this.Commit();
        }
        public void CreateDataTentaint()
        {
            new EntityTransaction(this._databaseCore.Clone()).DoTransantion<UserService, TenantService, TenantUserService>((T, T1, T2, T3) =>
            {
                long userId;
                long adminId;
                long tentantId;
                //1
                adminId= userId =T1.Insert(new UserModel()
                {
                    CreateBy = 0,
                    CreateAt = DateTime.Now,
                    UserName = "admin",
                    Email = "admin@jobvina.vn",
                    PhoneNumber = "0344638697",
                    Password = "Admin@12",
                    Status = EntityStatus.Active,
                    IsTenant=true
                }.DoAction(p => p.SetPassword()));
                tentantId = T2.Insert(new TenantModel()
                {
                    Name = "CÔNG TY TNHH CUNG ỨNG NHÂN LỰC Jobvina",
                    Address = "Đông du, Xã Đào Viên, Huyện Quế Võ, Tỉnh Bắc Ninh",
                    PhoneNumber = "0344638697",
                    Email = "contact@jobvina.vn",
                    IsShowHome = true,
                    CreateAt= DateTime.Now,
                    CreateBy= adminId,
                });
                T3.Insert(new TenantUserModel() { 
                    TenantId=tentantId,
                    UserId=userId,
                    Status=AZCore.Identity.TenantUserStatus.Active,
                    CreateAt= DateTime.Now,
                    CreateBy= adminId,
                });

                //2
                userId = T1.Insert(new UserModel()
                {
                    CreateBy = adminId,
                    CreateAt = DateTime.Now,
                    UserName = "admin.hqvian",
                    Email = "admin.hqvian@jobvina.vn",
                    PhoneNumber = "0344638610",
                    Password = "Admin@12@hqvian",
                    Status = EntityStatus.Active,
                    IsTenant = true
                }.DoAction(p => p.SetPassword()));
                tentantId = T2.Insert(new TenantModel()
                {
                    Name = "CÔNG TY TNHH CUNG ỨNG NHÂN LỰC HQ-VINA",
                    Address = "Huyện Quế Võ, Tỉnh Bắc Ninh",
                    PhoneNumber = "0344638697",
                    Email = "hq.vina@jobvina.vn",
                    IsShowHome = true,
                     CreateAt = DateTime.Now,
                     CreateBy = adminId,
                 });

                T3.Insert(new TenantUserModel()
                {
                    TenantId = tentantId,
                    UserId = userId,
                    Status = AZCore.Identity.TenantUserStatus.Active,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });
                ///3
                userId = T1.Insert(new UserModel()
                {
                    CreateBy = adminId,
                    CreateAt = DateTime.Now,
                    UserName = "admin.trithucviet",
                    Email = "admin.trithucviet@jobvina.vn",
                    PhoneNumber = "0344638612",
                    Password = "Admin@12@trithucviet",
                    Status = EntityStatus.Active,
                    IsTenant = true
                }.DoAction(p => p.SetPassword()));
                tentantId = T2.Insert(new TenantModel()
                {
                    Name = "CÔNG TY TNHH CUNG ỨNG NHÂN LỰC Tri thức việt",
                    Address = "Huyện Quế Võ, Tỉnh Bắc Ninh",
                    PhoneNumber = "0344638697",
                    Email = "trithucviet@jobvina.vn",
                    IsShowHome = true,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });

                T3.Insert(new TenantUserModel()
                {
                    TenantId = tentantId,
                    UserId = userId,
                    Status = AZCore.Identity.TenantUserStatus.Active,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });
                ///4
                userId = T1.Insert(new UserModel()
                {
                    CreateBy = adminId,
                    CreateAt = DateTime.Now,
                    UserName = "admin.dahashi",
                    Email = "admin.dahashi@jobvina.vn",
                    PhoneNumber = "0344638612",
                    Password = "Admin@12@dahashi",
                    Status = EntityStatus.Active,
                    IsTenant = true
                }.DoAction(p => p.SetPassword()));
                tentantId = T2.Insert(new TenantModel()
                {
                    Name = "CÔNG TY TNHH CUNG ỨNG NHÂN LỰC DAHASHI",
                    Address = "Huyện Quế Võ, Tỉnh Bắc Ninh",
                    PhoneNumber = "0344638697",
                    Email = "dahashi@jobvina.vn",
                    IsShowHome = true,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });
                T3.Insert(new TenantUserModel()
                {
                    TenantId = tentantId,
                    UserId = userId,
                    Status = AZCore.Identity.TenantUserStatus.Active,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });
                ///5
                userId = T1.Insert(new UserModel()
                {
                    CreateBy = adminId,
                    CreateAt = DateTime.Now,
                    UserName = "admin.dosungvina",
                    Email = "admin.dosungvina@jobvina.vn",
                    PhoneNumber = "0344638612",
                    Password = "Admin@12@dosungvina",
                    Status = EntityStatus.Active,
                    IsTenant = true
                }.DoAction(p => p.SetPassword()));
                tentantId = T2.Insert(new TenantModel()
                {
                    Name = "CÔNG TY TNHH CUNG ỨNG NHÂN LỰC Dosung Vina",
                    Address = "Xã Phương liễu, Huyện Quế Võ, Tỉnh Bắc Ninh",
                    PhoneNumber = "0935054224",
                    Email = "dosungvina@jobvina.vn",
                    IsShowHome = true,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });
                T3.Insert(new TenantUserModel()
                {
                    TenantId = tentantId,
                    UserId = userId,
                    Status = AZCore.Identity.TenantUserStatus.Active,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });
                ///6
                userId = T1.Insert(new UserModel()
                {
                    CreateBy = adminId,
                    CreateAt = DateTime.Now,
                    UserName = "admin.nhankien",
                    Email = "admin.nhankien@jobvina.vn",
                    PhoneNumber = "0344638612",
                    Password = "Admin@12@nhankien",
                    Status = EntityStatus.Active,
                    IsTenant = true
                }.DoAction(p => p.SetPassword()));
                tentantId = T2.Insert(new TenantModel() { 
                    Name= "CÔNG TY TNHH CUNG ỨNG NHÂN LỰC NHÂN KIỆT",
                    Address= "Phòng 202, Tòa Nhà 57, Số 57 Lê Thị Hồng Gấm, Phường Nguyễn Thái Bình, Quận 1, TP. HCM",
                    PhoneNumber= "08.35054224",
                    Email="nhankien@jobvina.vn",
                    IsShowHome=true,
                    CreateAt = DateTime.Now,
                    CreateBy = adminId,
                });
                //100
                for (var i = 0; i < 500; i++) {

                    userId = T1.Insert(new UserModel()
                    {
                        CreateBy = 0,
                        CreateAt = DateTime.Now,
                        UserName = "admin{0}".Frmat(i),
                        Email = "admin{0}@jobvina.vn".Frmat(i),
                        PhoneNumber = "0{0}344638697".Frmat(i),
                        Password = "Admin@12@{0}".Frmat(i),
                        Status = EntityStatus.Active,
                        IsTenant = true
                    }.DoAction(p => p.SetPassword()));
                    tentantId = T2.Insert(new TenantModel()
                    {
                        Name = "CÔNG TY TNHH CUNG ỨNG NHÂN LỰC Jobvina {0}".Frmat(i),
                        Address = "Đông du, Xã Đào Viên, Huyện Quế Võ, Tỉnh Bắc Ninh",
                        PhoneNumber = "0344638697",
                        Email = "contact{0}@jobvina.vn".Frmat(i),
                        IsShowHome = true,
                        CreateAt = DateTime.Now,
                        CreateBy = adminId,
                    });
                    T3.Insert(new TenantUserModel()
                    {
                        TenantId = tentantId,
                        UserId = userId,
                        Status = AZCore.Identity.TenantUserStatus.Active,
                        CreateAt = DateTime.Now,
                        CreateBy = adminId,
                    });
                }
                
            });
        }
        public void CreateLocation()
        {

        }
    }
}
