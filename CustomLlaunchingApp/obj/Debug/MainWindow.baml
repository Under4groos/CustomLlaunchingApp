   M S B A M L   `   `   `  ����N  JCustomLlaunchingApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:CustomLlaunchingAppCustomLlaunchingApp  5   P   K*clr-namespace:CustomLlaunchingApp.ControlsCustomLlaunchingApp.Controls  5   	   $    CustomLlaunchingApp.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Acustomllaunchingapp!clr-namespace:CustomLlaunchingApp     6P   ?Controls*clr-namespace:CustomLlaunchingApp.Controls     5   	     � AllowsTransparency  .  � WindowStyle$
 None=�5   4    � Title$ 
MainWindow��5   	   $	��450��6   $	��800��6)    � 	Resources 5	         style_border_1 �� 
TargetType �� Property �� Value �� Triggers P� Property	 P� Value��%9  &	        �� 5
   
   " ��6'   .�5      ��  � �� �	#0CFFFFFF6+   �� 5       � ��$ 30��6&   �� 5       � ��$ 30��6'   �� 5       � ��$ 0,5,5,0q�6'    5      P� 5       �@J�IsMouseOver	 . . �5      ��  � �� �	#19FFFFFF63   5      5      5      ��5      �� 5   
   
 �� Color$
 #262729��6    �� Opacity$	 0.7Q�6*   .��5      � -   5         �Name$ grid_new_app��5       J� 	AllowDrop . .+�5   
     CustomLlaunchingApp.DGrid  -   5          Name$ prog_panels��5   $   5!      �� 5"   
   $��Right=�6   $	��Top=�62   .+�5#      �� #��[  6   ._�5$      �� $��Segoe MDL2 Assets)�6   $	����5%      
�������$��20(�5'      5)      �� 5*      -   5         ��Name$ border_add_app��5*      #��[  6-   ._�5+      �� $��Segoe MDL2 Assets)�6   $	����5,      
�������$��20(�5.      $��Center=�6"   $��Center=�6?   50      51      �� 54   
   -   5         ��Name$ ldebug��54      $y�	Collapsed=�6    $
��Left=�67   $	��Top=�6R   
�������6j   55      56      