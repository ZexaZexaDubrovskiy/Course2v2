   M S B A M L   `   `   `  ????A  =Realty, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Realty.BaseWindowsRealty.BaseWindows  5   	   &     Realty.BaseWindows.Authorization   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Realty.BaseWindows     5   	     ? Title$  Authorization??5   	   $	??640??5	   	   $	??620??6   $	??640??5
   	   $	??620??6   $	??640??5   	   $	??620??6    ? WindowStartupLocation$ CenterScreen=?5   	   .??5      ?  ? RowDefinitions 5   
   ?? 5      $??70 ?6   ?? 5      $??50 ?6   ?? 5      $	??450 ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??10 ?6   ?? 5      $	??600 ?6   ?? 5      $??* ?6   .+?5   
   ?? $??5??6   $??5??6$   $??/Images/back.png??65   $
??Fill=?5       J? Opacity$	 0.3Q?6   ?? 5   
   $??1??6   $??1??6%   $??2??62   .+?5      ?? ???#C4E3CB$	??600??6'   $	??500??63    ?? RadiusX$	 100??5       ?? RadiusY$	 100??6&   $??Center=?64   $??Center=?5       5!      ?? 5$   
   $??1??6   $??2??6%    ?? Orientation$ Vertical=?62   .+?5&      ?? $ 
Horizontal=?6   $??Center=?62   .+?5'      ?? $??Авторизация??6   
?????? 
???????$
??Bold"?5(      $??38(?6.   $??0q?6<   $	??260??5)      $??60??6(    J? Effect 5*      3  -System.Windows.Media.Effects.DropShadowEffect  5+      	   ShadowDepth$	 1Q?6+   5-      5.      ?? 50      $ 
Horizontal=?6   $??Center=?62   $??0,20,0,0q?6O   .+?51      ?? -   5        
 ??Name$
 	userLogin??51      $	??550??6-   $??50??69   ???#8AAE92$??Center=?52      $
??Left=?6>   $??28(?53      
???????$
??Bold"?6;   $??	10,0,10,0q?6M   .??56      57      58      ?? 5:      $ 
Horizontal=?6   $??Center=?62   $??0,20,0,0q?6O   .+?5<      ?? -   5        $
 userPassword??5<      $??0??60   $??50??6:   ???#8AAE92$??Center=?5=      $
??Left=?6>   $??28(?5>      
???????$
??Bold"?6;   $??	10,0,10,0q?6M   $??1??5?      $y?Hidden=?6'   G? 5A      -   5         G?Name$ userConfirmPassword??5A      $	??450??6;   $??50??6G   ???#8AAE92$??Center=?5B      $
??Left=?6>   $??28(?5C      
???????$
??Bold"?6;   $??	10,0,10,0q?6M   $??2??5D      ?? 5G      -   5         ??Name$ PasswordButton??5H      ???#8AAE92$??90??5G   .   $??40??69    ?? 	IsDefault . $??1??5I   *   $??10,0,0,0q?67   .??5J      ?? -   5        $
 
textButton??5J   .   $??Показать??6   
???????
?????? $??18(?5K      $??0q?6,    ?? 
IsReadOnly . |?.  5L   0    ? 	Resources 5M       ?? 
TargetType ?? Property ?? Value??%_   '??       ?? 5N      " ??6    .?5O      ??  ?@??CornerRadius$ 10??6=   5P      5Q      5R      5T      ?? 5V      $ 
Horizontal=?6   $??Center=?62   $??	0,100,0,0q?6O   .+?5W      ?? -   5        $ signInButton??5W   F   ???#8AAE92$	??300??6.   $??60??6:   .??5Y      ?? $??Вход??6   
???????
?????? $
??Bold"?5Z      $??24(?60   $??0q?6>    . |?.  5[   0    5\      ??%_   '??       ?? 5]      " ??6    .?5^      ??  ?@??CornerRadius$ 30??6=   5_      5`      5a      5b      ?? 5d      $ 
Horizontal=?6   $??Center=?62   $??0,20,0,0q?6O   .+?5e      ?? -   5         ??Name$ ButtonSignUp??5f      $??Регистрация??5e      
?????? 
???????$
??Bold"?5g      $??20(?6.   $??0q?6<   $	??130??5h      $??37??6(    5m        5n      $	 1Q?6+   5p      5q      5s      ?? 5u   
   $ 
Horizontal=?6   $??0??6.   $??2??6;   $??1??5v      $??Bottom=?6%   $??Center=?6@   $??0,0,0,0q?5w      .+?5x      ?? $	??200??6   $	??100??6!   $??0,0,0,0q?6.   ???#616161.??5y      ?? $
??Left=?6   $	??200??6.   $	??100??6:   $??/Images/home.png??5z      5{      5|      5~      5      