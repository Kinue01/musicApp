   M S B A M L   `   `   `  ���� L  HmusicApp_clean.UI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:musicApp_clean.UImusicApp_clean.UI  +    %musicApp_clean.UI.View.NavigationView   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     1localclr-namespace:musicApp_clean.UI       � Title$  
MainWindow��$	��450��$	��800��.���  � ColumnDefinitions �� $��* ��� $
��3.7* � � RowDefinitions �� $	��10* ��� $��* �.+��� $��0��$��0��
�������._��� $��Center=�$��0 20 0 0q�.+��� $
��Home������ *NavigateHomeCommand+�� $��Список музыки������ *NavigateMusicsCommand+�� $��0��$��1��$��2��
�������._���  �� Orientation$ 
Horizontal=�$��	10 0 10 0q�.+��� $��30��$��30���� $ Vertical=�$��	10 0 10 0q�.+��� $
��FSAF���� $��dgsdgdsgsdgs���� $
��Prev���� $
��Play������ *ContinueCommand+�� $
��Next���� $��20��$	��400���� $��20��$��80���� $��1��$��0������ *NavigationService.CurrentView+