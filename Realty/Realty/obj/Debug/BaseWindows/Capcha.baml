   M S B A M L   `   `   `  ????A  =Realty, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:Realty.BaseWindowsRealty.BaseWindows  5   	       Realty.BaseWindows.Capcha   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:Realty.BaseWindows     5   	     ? Title$   ??5   	   $	??200??6   $	??300??6    ? 
ResizeMode$ NoResize=?6+    ? WindowStartupLocation$ CenterScreen=?6A   .??5	      ?  ? RowDefinitions 5
   
   ?? 5      $??75 ?6   ?? 5      $??75 ?6   ?? 5      $??* ?6    ? ColumnDefinitions 5   
   ?? 5      $??10 ?6   ?? 5      $	??270 ?6   ?? 5      $??10 ?6   .+?5   
   ?? $??5??6   $??5??6$   $??/Images/back.png??65   $
??Fill=?5       J? Opacity$	 0.3Q?6   ?? 5   
    ?? Orientation$ 
Horizontal=?6   $??0??6.   $??1??6;   $??Center=?6L   .+?5      ?? -   5        $??textBox1??5   %   $??50??5      $??28(?6"   
??? ? ?$??Italic$?6C   $??Heavy"?5      $	??185??65    ?? TextDecorations$ Strikethrough{?6A   $??UltraCondensed&?5      ?? 5      -   5        $??button1??5   4   $??обновить??6   $??31??6(   $??10,0,0,0q?6C   $??75??6U   6`   5      ?? 5    
   $ 
Horizontal=?6   $??1??6.   $??1??6;   $??Center=?6L   .+?5!      ?? -   5        $??textBox2??5"   %   $??50??5!      $??28(?6"   
??? ? ?$??Italic$?6C   $??Heavy"?5"      $	??185??65   $ Strikethrough{?6A   $??UltraCondensed&?5#      ?? 5$      -   5        $??button2??5$   7   $??подтвердить??6   $??31??6+   $??10,0,0,0q?6F   $??75??6X   6c   5%      5(      5*      