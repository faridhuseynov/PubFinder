   M S B A M L   `   `   `  ����D  @PubFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PubFinder.ViewsPubFinder.Views  5      ;"clr-namespace:PubFinder.ViewModelsPubFinder.ViewModels  5      #    PubFinder.Views.StartPageView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      )localclr-namespace:PubFinder.Views  5      +vm"clr-namespace:PubFinder.ViewModels  5        � 	Resources  5         ButtonControlTemplate1 �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels ��Name �� ContentStringFormat �� ContentStringFormat �� Triggers	 P� Property
 P� Value �� 
TargetName �� Value �� Property��%t  &	        �� 5   
   " ��69   .R�5      �� $ border��6   $ 25��6%   #��z��67   #��z��6c   #��z��6�    . ._�5      �� $ contentPresenter��6#   #��z��6=   #��z��6q   # z 6�   |�.  #��z��6�   #��z��6&  ��. # z 6d  #��z��6�  5       5      P� 5      	 �@��IsDefaulted
 . . �5      �� $ border��64   # � ��6H    � ��5      P� 5      	 �@J�IsMouseOver
 . . �5      �� $ border��63    � �� �	#FFBEE6FD6G   �� 5      $ border��64    � �� �	#FF3C7FB16H   5      P� 5      	 � ��
 . . �5      �� $ border��63    � �� �	#FFC4E5F66G   �� 5      $ border��64    � �� �	#FF2C628B6H   5      P� 5      	 �@d�	IsChecked$

 TrueY�6<   . �5      �� $ border��63    � �� �	#FFBCDDEE6G   �� 5      $ border��64    � �� �	#FF245A836H   5       P� 5!      	 � {�
 .  . �5"      �� $ border��63    � �� �	#FFF4F4F46G   �� 5#      $ border��64    � �� �	#FFADB2B56H   �� 5$       � �� �	#FF83838363   5%      5'      5(      .��5)      � ��5*   
   �� 5+       �� ImageSource$# ../Sources/beer-theme-bg9.jpg��6    j� Stretch$ UniformToFill=�5,       � RowDefinitions 5/   
   �� 50      6   �� 51      6   �� 52      6   �� 53      6   �� 54      6   .+�56   
   �� $��0��6   $4��.../Sources/pin-place-beer-pub-location-512.png��6   $��Center=�57      58      ]� 59   
   ��.  $��1��5:      $��Center=�5;      $
��0 20q�5<      .+�5=      �� $��Center=�6   $��30(�5>      
�������$	��Top=�5?      $��Username��5@      6)   �� 5A      -   5        $��UserName��5A   .   $��Bottom=�6   $��20(�6>   $��Center=�5B      $��Bottom=�5C      
���������5E      �� *
Username+ �� ValidatesOnDataErrors .  �� NotifyOnValidationError .  �� UpdateSourceTrigger$ PropertyChanged=�5H   9   5I      ]� 5J   
   $��2��6   $��Bottom=�5K      ��.  $��Center=�5M      .+�5N      �� $��Center=�6   $	��Top=�5O      $��30(�5P      
�������$��Password��5Q      6%   G� 5R      -   5         G�Name$ password��5R      $��30(�6,   $��Bottom=�5S      
�������$��Bottom=�5U      $��Center=�5V      5W      5X      �� 5\   
   $��20(�6   
�������$��3��62   ��5]      �� *%#(Validation.Errors)[0].ErrorContent+ �� ElementName$ password��]� 5^   
   $��3��6   $��Bottom=�6"   .+�5_      A� $��Bottom=�6   .+�5`      	� -   5         	�Name$ 
UserButton��5a      $��20(�5`      $��5q�5b      
�������$��Center=�5c      $��Center=�5d      
������� d� 	IsChecked 5f      �� *
UserRadBut+.��6<   User5g      	� 5h      -   5        $ OwnerButton��5i      $��20(�5h      $��5q�5j      
�������$��Center=�5k      $��Center=�5l       5m      �� *OwnerRadBut+.��6@   	Pub Owner5n       5o      5p      ]� 5q   
   $��4��6   $��Center=�6!   ��.  .+�5s      �� $��20(�6   $��Right=�6#   $��	0 0 10 30q�5t      $��20q�6,   $��70��69   #���   5u   :   $��Login��5w      ��5u      �� *LoginCommand+��5v      �� $ password����5x      �� 5y       �� EndPoint$ 0.5,1&�6*    �� 
StartPoint$ 0.5,0&�6;   .��5z      �  � Color$ 
LightGreen��6'    � Offset$ 0Q�6:   � 5{      $ 	#FF8FDC87��6'   $ 1Q�69   5|      ��5~      �� 5      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ Black��6'   $ 0Q�65   � 5�      $ 	#FF27F408��6'   $ 1Q�69   5�      ��5�      �� 5�       �� 
TargetType" ��6   LoginButton��.�5�      ��  � {� .  66    �� Triggers 5�      �� 5�       �� Binding 6*   �� *	IsChecked+$ 
UserButton�� �� Value True6`   .a�5�   "   ��  � {� . 6>   5�      �� 5�       6*   �� *	IsChecked+$ OwnerButton�� True6a   .a�5�   "   ��  � {� . 6>   5�      5�      5�      �� 5�      $��20(�6   $
��Left=�6#   $��70��5�      $��	0 0 10 30q�5�      $��20q�6(   $��Sign Up��5�   7   #���   6I   ��6   �� *SignUpCommand+��5�      �� 5�      $ 0.5,1&�6*   $ 0.5,0&�6;   .��5�      � $ 	LightBlue��6'   $ 0Q�69   � 5�      $ 	#FFC8FEFF��6'   $ 1Q�69   5�      ��5�      �� 5�      " ��6   .�5�      ��  � {� .  66    5�      �� 5�       6*   �� *	IsChecked+$ 
UserButton�� True6`   .a�5�   "   ��  � {� . 6>   5�      �� 5�       6*   �� *	IsChecked+$ OwnerButton�� True6a   .a�5�   "   ��  � {� . 6>   5�      5�      5�      5�      5�      5�      