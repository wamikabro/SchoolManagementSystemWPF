   M S B A M L   `   `   `  ����Q  MSchoolManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null[2clr-namespace:SchoolManagementSystem.User_Controls$SchoolManagementSystem.User_Controls  5      ?    9SchoolManagementSystem.User_Controls.TeacherDetailsDialog   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Dlocal2clr-namespace:SchoolManagementSystem.User_Controls     5      .��5	      �    BackgroundBrush#���   6   .+�5   
   �� -   5        $��	EditLabel��5   T   $
��Edit��6   $��Right=�6e   $	��Top=�6�   $��0,5,5,0q�6�     � Cursor$
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
IsSelected . 66   �� 5       $��Female��6'   5!      5"      �� 5#      $ Vertical=�6   .+�5$      �� $��Grade��6   $
��Left=�6,   �� 5%      -   5        $��GradeComboBox��5%   1   {�.  $
��Left=�6F   $	��150��6a   .@�5&      �� $��1��6'    . 63   �� 5'      $��2��6'   �� 5(      $��3��6'   �� 5)      $��4��6'   �� 5*      $��5��6'   �� 5+      $��6��6'   �� 5,      $��7��6'   �� 5-      $��8��6'   5.      5/      �� 50      $ Vertical=�6   .+�51      �� $��Phone Number��6   $
��Left=�63   �� 52      -   5        $��PhoneNumberTextBox��52   0    . $	��150��6J   $
��Left=�6V   53      54      �� 55      $��40,0,0,0q�6   .+�56      �� $ Vertical=�6   .+�57      �� $��Email��6   $
��Left=�6,   �� 58      -   5        $ EmailTextBox��58   0    . $	��150��6F   $
��Left=�6R   59      �� 5;      $ Vertical=�6   .+�5<      �� $��Blood Group��6   $
��Left=�62   �� 5=      -	   5         ��Name$ BloodGroupComboBox��5=   1   {�.  $	��150��6M   $
��Left=�6Y   .@�5>      �� $��	ONegative��6'    . 6;   �� 5?      $��	OPositive��6'   �� 5@      $��	ANegative��6'   �� 5A      $��	APositive��6'   �� 5B      $��	BNegative��6'   �� 5C      $��	BPositive��6'   �� 5D      $��
ABNegative��6'   �� 5E      $��
ABPositive��6'   5F      5G      �� 5I      $ Vertical=�6   .+�5J      �� $��Address��6   $
��Left=�6.   �� 5K      -
   5        $ AddressTextBox��5K   0    . $	��150��6H   $
��Left=�6T   5L      �� 5N      $ Vertical=�6   .+�5O      �� $��Subject��6   $
��Left=�6.   �� 5P      -   5        $ SubjectTextBox��5P   0    . $	��150��6H   $
��Left=�6T   5Q      �� 5S      $ Vertical=�6   .+�5T      �� $��Date of Birth��6   $
��Left=�64   (  "System.Windows.Controls.DatePicker  5U      -   5          Name$ DOBDatePicker��5U   3   {�.  $	��150��6J   $
��Left=�6V   $��35��6q   5V      �� 5X      $ Vertical=�6   .+�5Y      �� $��Date of Admission��6   $
��Left=�68     5Z      -   5        $ DOADatePicker��5Z   3   {�.  $	��150��6J   $
��Left=�6V   $��35��6q   5[      5\      5]      �� 5`   
   $ 
Horizontal=�6   $��Center=�6.   $��Bottom=�6K   .+�5a      �� -   5        $��
OkayButton��5a      $
��Okay��6@   $��30��6O   $	��120��6[   $��0,0,10,5q�6i   �� 5b      -   5        $��
SaveButton��5b   .   $
��Save��6@   {�.  $��30��6a   $	��120��6m   $��10,0,0,5q�6{   5c      5d      5e      