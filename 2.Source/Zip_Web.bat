@ECHO OFF

RMDIR /Q/S "./2.1.Web/Apps/AZERP/bin/"
RMDIR /Q/S "./2.1.Web/Apps/AZERP.Data/bin/"
RMDIR /Q/S "./2.1.Web/Libs/AZCore/bin/"
RMDIR /Q/S "./2.1.Web/Libs/AZSocial/bin/"
RMDIR /Q/S "./2.1.Web/Libs/AZWeb/bin/"
RMDIR /Q/S "./2.1.Web/Test/AZSocial.Test/bin/"

RMDIR /Q/S "./2.1.Web/Apps/AZERP/obj/"
RMDIR /Q/S "./2.1.Web/Apps/AZERP.Data/obj/"
RMDIR /Q/S "./2.1.Web/Libs/AZCore/obj/"
RMDIR /Q/S "./2.1.Web/Libs/AZSocial/obj/"
RMDIR /Q/S "./2.1.Web/Libs/AZWeb/obj/"
RMDIR /Q/S "./2.1.Web/Test/AZSocial.Test/obj/"

powershell Compress-Archive ./2.1.Web 2.1.Web.zip

msgbox "Zip Done"