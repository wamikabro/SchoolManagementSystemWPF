   M S B A M L   `   `   `  ����Q  MSchoolManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SchoolManagementSystem.User_Controls$SchoolManagementSystem.User_Controls  5      =    7SchoolManagementSystem.User_Controls.StaffDetailsDialog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:SchoolManagementSystem.User_Controls     5      .��5	      �    BackgroundBrush#���   6   .+�5   
   �� -   5        $��	EditLabel��5   S   $
��Edit��6D   $��Right=�6d   $	��Top=�6�   $��0,5,5,0q�6�     � Cursor$
  Hand��6�   �� 5   
   $��10q�6    �� Orientation$ 
Horizontal=�6!   .+�5      �� $��20,0,0,0q�6   .+�5      �� $ Vertical=�6   .+�5      �� $��
First Name��6   $
��Left=�61   �� 5      -   5         ��Name$ FirstNameTextBox��5      $
��Left=�68   $	��150��6S    �� 
IsReadOnly . 6_   5      �� 5      $ Vertical=�6   .+�5      �� $��	Last Name��6   $
��Left=�60   �� 5      -   5        $ LastNameTextBox��5      $
��Left=�67   $	��150��6R    . 6^   5      �� 5      $ Vertical=�6   .+�5      �� $��Father Name��6   $
��Left=�62   �� 5      -   5        $ FatherNameTextBox��5      $
��Left=�69   $	��150��6T    . 6`   5      �� 5      $ Vertical=�6   .+�5      �� $��Gender��6   $
��Left=�6-   �� 5      -   5        $��GenderComboBox��5   1   {�.  $
��Left=�6G   $	��150��6b   .@�5      �� $
��Male��6'    �� 
IsSelected . 66   �� 5       $��Female��6'   5!      5"      �� 5#      $ Vertical=�6   .+�5$      �� $��	Job Title��6   $
��Left=�60   �� 5%      -   5        $��JobTitleTextBox��5%   0    . $	��150��6G   $
��Left=�6S   5&      �� 5'      $ Vertical=�6   .+�5(      �� $��Phone Number��6   $
��Left=�63   �� 5)      -   5        $��PhoneNumberTextBox��5)   0    . $	��150��6J   $
��Left=�6V   5*      5+      �� 5,      $��40,0,0,0q�6   .+�5-      �� $ Vertical=�6   .+�5.      �� $��Email��6   $
��Left=�6,   �� 5/      -   5        $ EmailTextBox��5/   0    . $	��150��6F   $
��Left=�6R   50      �� 52      $ Vertical=�6   .+�53      �� $��Blood Group��6   $
��Left=�62   �� 54      -	   5         ��Name$ BloodGroupComboBox��54   1   {�.  $	��150��6M   $
��Left=�6Y   .@�55      �� $��	ONegative��6'    . 6;   �� 56      $��	OPositive��6'   �� 57      $��	ANegative��6'   �� 58      $��	APositive��6'   �� 59      $��	BNegative��6'   �� 5:      $��	BPositive��6'   �� 5;      $��
ABNegative��6'   �� 5<      $��
ABPositive��6'   5=      5>      �� 5@      $ Vertical=�6   .+�5A      �� $��Address��6   $
��Left=�6.   �� 5B      -
   5        $ AddressTextBox��5B   0    . $	��150��6H   $
��Left=�6T   5C      �� 5E      $ Vertical=�6   �� 5G      $ Vertical=�6   .+�5H      �� $��Date of Birth��6   $
��Left=�64   (  "System.Windows.Controls.DatePicker  5I      -   5          Name$ DOBDatePicker��5I   3   {�.  $	��150��6J   $
��Left=�6V   $��35��6q   5J      �� 5L      $ Vertical=�6   .+�5M      �� $��Date of Admission��6   $
��Left=�68     5N      -   5        $ DOADatePicker��5N   3   {�.  $	��150��6J   $
��Left=�6V   $��35��6q   5O      5P      5Q      �� 5T   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   .+�5U      �� -   5        $��
OkayButton��5U      $
��Okay��6@   $��30��6O   $	��120��6[   $��0,0,10,5q�6i   �� 5V      -   5        $��
SaveButton��5V   .   $
��Save��6@   {�.  $��30��6a   $	��120��6m   $��10,0,0,5q�6{   5W      5X      5Y      