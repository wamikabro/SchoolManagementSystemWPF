   M S B A M L   `   `   `  ����Q  MSchoolManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:SchoolManagementSystemSchoolManagementSystem  5   	   !    SchoolManagementSystem.Home   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Z VFontAwesome.WPF, Version=4.7.0.37774, Culture=neutral, PublicKeyToken=0758b07a11a4f466-fa$http://schemas.fontawesome.io/icons/  5   	   0local$clr-namespace:SchoolManagementSystem  5   	     � Title$
  Home��5	   	   $	��450��6   $	��800��6#    � WindowState$ 	Maximized=�6/   .��5      �    BackgroundBrush#���   6    � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $	��300��6!   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$ 1,0.7&�67   .��5      �   secondaryBackColor1 � Color# �  6#    � Offset$ 0Q�6Q   � 5        secondaryBackColor2# �  6#   $ 1Q�6Q   5      ._�5      �� .+�5      	� -   5         	�Name$ 
homeButton��5!   !     
menuButton#���  5       
 color1
 � Tag# �  6C   	 d� 	IsChecked$
	 TrueY�5   !   ��5    !   �� *HomeViewCommand+.��5#      �� 
 �� Orientation$
 
Horizontal=�6!   .+�5$      "  FontAwesome.WPF.ImageAwesome     Icon$
 Home=�6*     menuButtonIcon#���  66   �� 5%      $
��Home��6$     menuButtonText#���  60   5&      5'      	� 5*      -   5        $ addNewButton��5*      #���  64    
 color3# �  6Y   .��5,      �� $
 
Horizontal=�6!   .+�5-        $
 Plus=�6*   #���  66   �� 5.      $��Add New��6$   #���  63   5/      50      �� 53      -   5         ��Name$ addButtonOptions��53      $y�	Collapsed=�67   .+�54      	� -   5        $ addStudentButton��55   "   #���  54   "    
 color6# �  6G   .��57      �� $
 
Horizontal=�6%   .+�58        $ UserPlus=�6.   #���  6>   �� 59      $��Add Student��6(   #���  6;   5:      5;      	� 5<      -   5        $ addTeacherButton��5=   "   #���  5<   "   # �  6G   .��5?      �� $
 
Horizontal=�6%   .+�5@        $ 	Clipboard=�6.   #���  6?   �� 5A      $��Add Teacher��6(   #���  6;   5B      5C      	� 5D      -   5        $ addStaffButton��5E   "   #���  5D   "   # �  6G   .��5G      �� $
 
Horizontal=�6%   .+�5H        $ 
UserCircle=�6.   #���  6@   �� 5I      $��	Add Staff��6(   #���  69   5J      5K      5L      	� 5O      -   5        $ searchButton��5O      #���  64    
	 color7# � 	 6Y   .��5Q      �� $
 
Horizontal=�6!   .+�5R        $ Search=�6*   #���  68   �� 5S      $��Search Existing��6$   #���  6;   5T      5U      �� 5X      -   5        $ searchButtonOptions��5X      $y�	Collapsed=�6:   .+�5Y      	� -	   5        $ searchStudentButton��5Z   "   #���  5Y   "    

 color5# � 
 6G   .��5\      �� $
 
Horizontal=�6%   .+�5]        $ UserPlus=�6.   #���  6>   �� 5^      $��Search Student��6(   #���  6>   5_      5`      	� 5a      -
   5        $ searchTeacherButton��5b   "   #���  5a   "   # � 
 6G   .��5d      �� $
 
Horizontal=�6%   .+�5e        $ 	Clipboard=�6.   #���  6?   �� 5f      $��Search Teacher��6(   #���  6>   5g      5h      	� 5i      -   5        $ searchStaffButton��5j   "   #���  5i   "   # � 
 6G   .��5l      �� $
 
Horizontal=�6%   .+�5m        $ 
UserCircle=�6.   #���  6@   �� 5n      $��Search Staff��6(   #���  6<   5o      5p      5q      	� 5t      -   5        $ settingsButton��5u      #���  5t       
 color9# �  6C   .��5w      �� $
 
Horizontal=�6!   .+�5x        $
 Gear=�6*   #���  66   �� 5y      $��Settings��6$   #���  64   5z      5{      	� 5~      -   5        $ reportButton��5      #���  5~       
 color4# �  6C   .��5�      �� $
 
Horizontal=�6!   .+�5�        $ MailForward=�6*   #���  6=   �� 5�      $��Report��6$   #���  62   5�      5�      5�      5�      �� 5�   
   $��1��6     mainContentBackgroundColor#���  6!   $��30,34,30,26q�6[    �� CornerRadius 5�      �� 5�       �� 
BottomLeft$ 15Q�6    �� BottomRight$ 15Q�6/    �� TopLeft$ 15Q�6@    �� TopRight$ 15Q�6M   ._�5�      � -   5         �Name$ MainContent��5�      5�      5�      5�      