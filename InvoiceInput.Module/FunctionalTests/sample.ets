;#DropDB InvoiceInputEasyTest

#Application InvoiceInput.Win
#Application InvoiceInput.Web
#IfDef InvoiceInput.Win

*Action About...
 
*Action OK

#EndIf

#IfDef InvoiceInput.Web
!Action Navigation(My Details)
#EndIf
