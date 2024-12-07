using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{

    /// <summary>
    /// 基础sql仓储
    /// </summary>
    public static class BaseSqlRepository
    {
        #region 表Sys_Menu

        /// <summary>
        /// Menu新增
        /// </summary>
        public static string menu_insertSql = @"insert into Sys_Menu (MenuUrl,MenuIcon,MenuTitle,Pid,IsOpen,CreateTime,CreateUser,Component,Path,RequireAuth,Name,Redirect) values(@MenuUrl,@MenuIcon,@MenuTitle,@Pid,@IsOpen,@CreateTime,@CreateUser,@Component,@Path,@RequireAuth,@Name,@Redirect)";

        /// <summary>
        /// Menu更新
        /// </summary>
        public static string menu_updateSql = @"update Sys_Menu set MenuUrl=@MenuUrl,MenuIcon = @MenuIcon ,MenuTitle=@MenuTitle,Pid=@Pid,IsOpen=@IsOpen ,CreateTime=@CreateTime,CreateUser=@CreateUser,Component=@Component,Path=@Path,RequireAuth=@RequireAuth,Name=@Name,Redirect=@Redirect where Id = @Id";

        /// <summary>
        /// Menu查询
        /// </summary>
        public static string menu_selectByKeySql = @" select * from Sys_Menu where  Id=@Key";

        /// <summary>
        /// Menu查询全部
        /// </summary>
        public static string menu_selectAllSql = @" select * from Sys_Menu";

        #endregion

        #region 表Sys_ExceptionLog

        /// <summary>
        /// Sys_ExceptionLog新增
        /// </summary>
        public static string exceptionLog_insertSql = @"insert into Sys_ExceptionLog (ExceptionType,ExceptionMsg,ExceptionTime,OperateUserName,OperateUserId,IsHandle,HandleUserName,HandleUserId) 
                                                        values(@ExceptionType,@ExceptionMsg,@ExceptionTime,@OperateUserName,@OperateUserId,@IsHandle,@HandleUserName,@HandleUserId)";

        #endregion

        #region 表Sys_user

        /// <summary>
        /// sys_user新增
        /// </summary>
        public static string sysUser_insertSql = @"insert into Sys_User (UserName ,Password ,Age,Sex,DepartmentId,CreateTime,CreateUser) values(@UserName ,@Password ,@Age,@Sex,@DepartmentId,@CreateTime,@CreateUser)";

        /// <summary>
        /// sys_user更新
        /// </summary>
        public static string sysUser_updateSql = @"update Sys_User set UserName=@UserName ,Password=@Password ,Age=@Age,Sex=@Sex,DepartmentId=@DepartmentId,CreateTime=@CreateTime,CreateUser=@CreateUser where UserId = @UserId";

        /// <summary>
        /// sys_user查询
        /// </summary>
        public static string sysUser_selectByKeySql = @" select * from Sys_User where  UserId=@Key";

        /// <summary>
        /// sys_user表查询全部语句
        /// </summary>
        public static string sysUser_selectAllSql = @" select * from Sys_User";

        #endregion

        #region 表Sys_Role

        /// <summary>
        /// Sys_Role新增
        /// </summary>
        public static string sysRole_insertSql = @"insert into Sys_Role (RoleName,CreateTime,CreateUser) values(@RoleName,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_Role更新
        /// </summary>
        public static string sysRole_updateSql = @"update Sys_Role set RoleName=@RoleName,CreateTime=@CreateTime,CreateUser=@CreateUser where RoleId = @RoleId";

        /// <summary>
        /// Sys_Role查询
        /// </summary>
        public static string sysRole_selectByKeySql = @" select * from Sys_Role where  RoleId=@Key";

        /// <summary>
        /// Sys_Role表查询全部语句
        /// </summary>
        public static string sysRole_selectAllSql = @" select * from Sys_Role";

        #endregion

        #region 表Sys_MenuRoleRelation

        /// <summary>
        /// Sys_MenuRoleRelation新增
        /// </summary>
        public static string sysMenuRoleRelation_insertSql = @"insert into Sys_MenuRoleRelation (MenuId,RoleId,CreateTime,CreateUser) values(@MenuId,@RoleId,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_MenuRoleRelation更新
        /// </summary>
        public static string sysMenuRoleRelation_updateSql = @"update Sys_MenuRoleRelation set MenuId=@MenuId,RoleId=@RoleId,CreateTime=@CreateTime,CreateUser=@CreateUser where MenuRoleId = @MenuRoleId";

        /// <summary>
        /// Sys_MenuRoleRelation查询
        /// </summary>
        public static string sysMenuRoleRelation_selectByKeySql = @" select * from Sys_MenuRoleRelation where  MenuRoleId=@Key";

        /// <summary>
        /// Sys_MenuRoleRelation表查询全部语句
        /// </summary>
        public static string sysMenuRoleRelation_selectAllSql = @" select * from Sys_MenuRoleRelation";

        #endregion

        #region 表Sys_UserRoleRelation

        /// <summary>
        /// Sys_UserRoleRelation新增
        /// </summary>
        public static string sysUserRoleRelation_insertSql = @"insert into Sys_UserRoleRelation (RoleId,UserId,CreateTime,CreateUser) values(@RoleId,@UserId,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_UserRoleRelation更新
        /// </summary>
        public static string sysUserRoleRelation_updateSql = @"update Sys_UserRoleRelation set RoleId=@RoleId,UserId=@UserId,CreateTime=@CreateTime,CreateUser=@CreateUser where UserRoleId = @UserRoleId";

        /// <summary>
        /// Sys_UserRoleRelation查询
        /// </summary>
        public static string sysUserRoleRelation_selectByKeySql = @" select * from Sys_UserRoleRelation where  UserRoleId=@Key";

        /// <summary>
        /// Sys_UserRoleRelation表查询全部语句
        /// </summary>
        public static string sysUserRoleRelation_selectAllSql = @" select * from Sys_UserRoleRelation";

        #endregion

        #region 表Sys_Button

        /// <summary>
        /// Sys_Button新增
        /// </summary>
        public static string sysButton_insertSql = @"insert into Sys_Button (ButtonName,ButtonKey,ButtonStyleId,MenuId,OrderBy,CreateTime,CreateUser) values(@ButtonName,@ButtonKey,@ButtonStyleId,@MenuId,@OrderBy,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_Button更新
        /// </summary>
        public static string sysButton_updateSql = @"update Sys_Button set ButtonName=@ButtonName,ButtonKey=@ButtonKey,ButtonStyleId=@ButtonStyleId,MenuId=@MenuId,OrderBy=@OrderBy,CreateTime=@CreateTime,CreateUser=@CreateUser where ButtonId = @ButtonId";

        /// <summary>
        /// Sys_Button查询
        /// </summary>
        public static string sysButton_selectByKeySql = @" select * from Sys_Button where  ButtonId=@Key";

        /// <summary>
        /// Sys_Button表查询全部语句
        /// </summary>
        public static string sysButton_selectAllSql = @" select * from Sys_Button";

        #endregion

        #region 表Sys_ButtonStyle

        /// <summary>
        /// Sys_ButtonStyle新增
        /// </summary>
        public static string sysButtonStyle_insertSql = @"insert into Sys_ButtonStyle (BordersStyle,Size,Types,Icon,ButtonStyleName,OrderBy,Borders,IsRadius,CreateTime,CreateUser) values(@BordersStyle,@Size,@Types,@Icon,@ButtonStyleName,@OrderBy,@Borders,@IsRadius,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_ButtonStyle更新
        /// </summary>
        public static string sysButtonStyle_updateSql = @"update Sys_ButtonStyle set BordersStyle=@BordersStyle,Size=@Size,Types=@Types,Icon=@Icon,ButtonStyleName=@ButtonStyleName,OrderBy=@OrderBy,Borders=@Borders,IsRadius=@IsRadius,CreateTime=@CreateTime,CreateUser=@CreateUser where ButtonStyleId = @ButtonStyleId";

        /// <summary>
        /// Sys_ButtonStyle查询
        /// </summary>
        public static string sysButtonStyle_selectByKeySql = @" select * from Sys_ButtonStyle where  ButtonStyleId=@Key";

        /// <summary>
        /// Sys_ButtonStyle表查询全部语句
        /// </summary>
        public static string sysButtonStyle_selectAllSql = @" select * from Sys_ButtonStyle";

        /// <summary>
        /// Sys_ButtonStyle 删除
        /// </summary>
        public static string sysButtonStyle_delete = @" delete from  Sys_ButtonStyle where ButtonStyleId=@Key";

        #endregion

        #region 表 Sys_ButtonRole

        /// <summary>
        /// Sys_ButtonRole 新增
        /// </summary>
        public static string sysButtonRole_insertSql = @"insert into Sys_ButtonRole (MenuId,ButtonId,RoleId,CreateTime,CreateUser) values(@MenuId,@ButtonId,@RoleId,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_ButtonRole 更新
        /// </summary>
        public static string sysButtonRole_updateSql = @"update Sys_ButtonRole set MenuId=@MenuId,ButtonId=@ButtonId,RoleId=@RoleId,CreateTime=@CreateTime,CreateUser=@CreateUser where ButtonRoleId = @ButtonRoleId";

        /// <summary>
        /// Sys_ButtonRole 查询
        /// </summary>
        public static string sysButtonRole_selectByKeySql = @" select * from Sys_ButtonRole where  ButtonRoleId=@Key";

        /// <summary>
        /// Sys_ButtonRole 表查询全部语句
        /// </summary>
        public static string sysButtonRole_selectAllSql = @" select * from Sys_ButtonRole";

        #endregion

        #region 表Sys_MenuTableCols

        /// <summary>
        /// Sys_MenuTableCols新增
        /// </summary>
        public static string sysMenuTableCols_insertSql = @"insert into Sys_MenuTableCols (MenuId,FieldName,FieldType,FieldTitle,FieldOrderBy,FieldWidth,FieldSort,FieldCustomSlot,FieldAlign,FieldFixed,FieldMinWidth,FieldEllipsisTooltip,CreateTime,CreateUser,IsSystemData,DataRowAuthType,DataRowAuthField,DataRowAuthFieldName) 
                                                            values(@MenuId,@FieldName,@FieldType,@FieldTitle,@FieldOrderBy,@FieldWidth,@FieldSort,@FieldCustomSlot,@FieldAlign,@FieldFixed,@FieldMinWidth,@FieldEllipsisTooltip,@CreateTime,@CreateUser,@IsSystemData,@DataRowAuthType,@DataRowAuthField,@DataRowAuthFieldName)";

        /// <summary>
        /// Sys_MenuTableCols更新
        /// </summary>
        public static string sysMenuTableCols_updateSql = @"update Sys_MenuTableCols set MenuId=@MenuId,FieldName=@FieldName,FieldType=@FieldType,FieldTitle=@FieldTitle,FieldOrderBy=@FieldOrderBy,FieldWidth=@FieldWidth,FieldSort=@FieldSort,
                                                            FieldCustomSlot=@FieldCustomSlot,FieldAlign=@FieldAlign,FieldFixed=@FieldFixed,FieldMinWidth=@FieldMinWidth,FieldEllipsisTooltip=@FieldEllipsisTooltip,CreateTime=@CreateTime,CreateUser=@CreateUser,DataRowAuthType=@DataRowAuthType,DataRowAuthField=@DataRowAuthField,DataRowAuthFieldName=@DataRowAuthFieldName where Id = @Id";

        /// <summary>
        /// Sys_MenuTableCols查询
        /// </summary>
        public static string sysMenuTableCols_selectByKeySql = @" select * from Sys_MenuTableCols where  Id=@Key";

        /// <summary>
        /// Sys_MenuTableCols表查询全部语句
        /// </summary>
        public static string sysMenuTableCols_selectAllSql = @" select * from Sys_MenuTableCols";

        /// <summary>
        /// Sys_MenuTableCols 删除
        /// </summary>
        public static string sysMenuTableCols_delete = @" delete from  Sys_MenuTableCols where Id=@Key";

        #endregion

        #region 表 Sys_MenuTableColsRole

        /// <summary>
        /// Sys_MenuTableColsRole 新增
        /// </summary>
        public static string sysMenuTableColsRole_insertSql = @"insert into Sys_MenuTableColsRole (MenuId,MenuTableColsId,RoleId,CreateTime,CreateUser) values(@MenuId,@MenuTableColsId,@RoleId,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_MenuTableColsRole 更新
        /// </summary>
        public static string sysMenuTableColsRole_updateSql = @"update Sys_MenuTableColsRole set MenuId=@MenuId,MenuTableColsId=@MenuTableColsId,RoleId=@RoleId,CreateTime=@CreateTime,CreateUser=@CreateUser where Id = @Id";

        /// <summary>
        /// Sys_MenuTableColsRole 查询
        /// </summary>
        public static string sysMenuTableColsRole_selectByKeySql = @" select * from Sys_MenuTableColsRole where  Id=@Key";

        /// <summary>
        /// Sys_MenuTableColsRole 表查询全部语句
        /// </summary>
        public static string sysMenuTableColsRole_selectAllSql = @" select * from Sys_MenuTableColsRole";

        /// <summary>
        /// Sys_MenuTableColsRole 删除
        /// </summary>
        public static string sysMenuTableColsRole_delete = @" delete from  Sys_MenuTableColsRole where Id=@Key";

        #endregion

        #region 表Sys_MenuTableRowAuth

        /// <summary>
        /// Sys_MenuTableRowAuth 新增
        /// </summary>
        public static string sysMenuTableRowAuth_insertSql = @"insert into Sys_MenuTableRowAuth (MenuId,RuleJson,IsOpen,Remark,Sort,CreateTime,CreateUser) values(@MenuId,@RuleJson,@IsOpen,@Remark,@Sort,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_MenuTableRowAuth 更新
        /// </summary>
        public static string sysMenuTableRowAuth_updateSql = @"update Sys_MenuTableRowAuth set MenuId=@MenuId,RuleJson=@RuleJson,IsOpen=@IsOpen,Remark=@Remark,Sort=@Sort,CreateTime=@CreateTime,CreateUser=@CreateUser where Id = @Id";

        /// <summary>
        /// Sys_MenuTableRowAuth 查询
        /// </summary>
        public static string sysMenuTableRowAuth_selectByKeySql = @" select * from Sys_MenuTableRowAuth where  Id=@Key";

        /// <summary>
        /// Sys_MenuTableRowAuth 表查询全部语句
        /// </summary>
        public static string sysMenuTableRowAuth_selectAllSql = @" select * from Sys_MenuTableRowAuth";

        /// <summary>
        /// Sys_MenuTableRowAuth 删除
        /// </summary>
        public static string sysMenuTableRowAuth_delete = @" delete from  Sys_MenuTableRowAuth where Id=@Key";

        #endregion

        #region 表Sys_MenuTableRowAuthConfig

        /// <summary>
        /// Sys_MenuTableRowAuthConfig 新增
        /// </summary>
        public static string sysMenuTableRowAuthConfig_insertSql = @"insert into Sys_MenuTableRowAuthConfig (MenuId,PermissionsField,PermissionsFieldName,ConditionalEquationValue,ShowControl,ShowControlDataSource,IsOpen,CreateTime,CreateUser) values(@MenuId,@PermissionsField,@PermissionsFieldName,@ConditionalEquationValue,@ShowControl,@ShowControlDataSource,@IsOpen,@CreateTime,@CreateUser)";

        /// <summary>
        /// Sys_MenuTableRowAuthConfig 更新
        /// </summary>
        public static string sysMenuTableRowAuthConfig_updateSql = @"update Sys_MenuTableRowAuthConfig set MenuId=@MenuId,PermissionsField=@PermissionsField,PermissionsFieldName=@PermissionsFieldName,ConditionalEquationValue=@ConditionalEquationValue,ShowControl=@ShowControl,ShowControlDataSource=@ShowControlDataSource,IsOpen=@IsOpen,CreateTime=@CreateTime,CreateUser=@CreateUser where Id = @Id";

        /// <summary>
        /// Sys_MenuTableRowAuthConfig 查询
        /// </summary>
        public static string sysMenuTableRowAuthConfig_selectByKeySql = @" select * from Sys_MenuTableRowAuthConfig where  Id=@Key";

        /// <summary>
        /// Sys_MenuTableRowAuthConfig 表查询全部语句
        /// </summary>
        public static string sysMenuTableRowAuthConfig_selectAllSql = @" select * from Sys_MenuTableRowAuthConfig";

        /// <summary>
        /// Sys_MenuTableRowAuthConfig 删除
        /// </summary>
        public static string sysMenuTableRowAuthConfig_delete = @" delete from  Sys_MenuTableRowAuthConfig where Id=@Key";

        #endregion
    }
}
