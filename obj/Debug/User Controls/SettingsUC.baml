   M S B A M L   `   `   `  ����Q  MSchoolManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SchoolManagementSystem.User_Controls$SchoolManagementSystem.User_Controls  5      5    /SchoolManagementSystem.User_Controls.SettingsUC   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:SchoolManagementSystem.User_Controls     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $
��Auto �6   .+�5   
   ��  �� Orientation$ Vertical=�6   .+�5      �� $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5      �� $��Theme��6   $
��Bold"�6(   $��
0,30,190,0q�6:   �� 5      -   5        $��ThemeSwitch��5   \   $��26(�6o   $��0,30,0,0q�6}   5      �� 5      $ 
Horizontal=�6   $��Center=�62   $��Center=�6M   .+�5      �� $��	Font Size��6   $
��Bold"�6,   $��	0,20,30,0q�6>   �� 5      -   5         ��Name$ FontSizeSlider��5      $	��200��62   $��22��6>    � Minimum$ 20Q�6J    � Maximum$ 40Q�6W   $��0,20,0,0q�6d    �� IsSnapToTickEnabled .  �� TickFrequency$ 1Q�6�   �� 5      $��Center=�6   $	��Top=�65   $��0,20,0,0q�6M   ��6_   ��  �� ElementName$ FontSizeSlider�� �� Path$ Value�5      �� 5      -   5        $��
SaveButton��5      $
��Save��6'   $��0,10,0,0q�66   6H   5      5      5      