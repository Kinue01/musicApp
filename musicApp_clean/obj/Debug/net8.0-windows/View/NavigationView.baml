   M S B A M L   `   `   `  ����L  HmusicApp_clean.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:musicApp_clean.UI.ViewmusicApp_clean.UI.View  5   	   +    %musicApp_clean.UI.View.NavigationView   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5view$clr-namespace:musicApp_clean.UI.View     5   	     � Title$  
MainWindow��5   	   $	��800��5	   	   $
��1100��5
   	   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $
��3.7* �6    � RowDefinitions 5   
   �� 5      $	��10* �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   
�������._�5      �� $��Center=�6   $��0 20 0 0q�66   .+�5      �� $
��Home��6   ��6(   �� *NavigateHomeCommand+�� 5      $��Список музыки��6   ��61   �� *NavigateMusicsCommand+5      5      �� 5   
   $��0��6   $��1��6)   $��2��66   ��6J   �� *$"NavigationService.MusicControlView+�� 5   
   $��1��6   $��0��6)   ��66   �� *NavigationService.CurrentView+5      5       