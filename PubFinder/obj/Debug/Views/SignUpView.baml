   M S B A M L   `   `   `  ����c  _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35qPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.InteractivitySystem.Windows.Interactivity  5      D @PubFinder, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PubFinder.ViewsPubFinder.Views 5      ;"clr-namespace:PubFinder.ViewModelsPubFinder.ViewModels 5          PubFinder.Views.SignUpView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ^iPclr-namespace:System.Windows.Interactivity;assembly=System.Windows.Interactivity     5      /localclr-namespace:PubFinder.Views     5      1vm"clr-namespace:PubFinder.ViewModels     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	        � 	Resources  5         pubLbTemplate��%g  &	        �� 5   
   .R�5      ]� ��. .+�5      �� $
��Left=�6   $��50��6K   ��6/   �� *
LogoLink+6X   �� 5      $��Right=�6   $	��4.2��60   
��� � �$
��Bold"�5   +   $��20(�5      
�������6?   �� 5      $��Right=�6   $��20(�6/   
�������
��������5      �� *Name+5   5   5      5      5      .��5      � 
�������.+�5   
   � $��50��6   $	��Top=�6   ���	#FF0D16D6.+�5      '  !MaterialDesignThemes.Wpf.PopupBox  $��Right=�6&      PlacementMode$ BottomAndAlignRightEdges=�5   &      	StaysOpen .  $��5q�5   &   ���	#FFFBFBFB   PopupContent. 5       �� $��Log out��6   ��6+   �� *LogOutCommand+��5!      �� 5"      5$      5%      5&      � 5'   
   -   5         �Name$ GridMenu��5'      $��Bottom=�6!   
��� ���.+�5(      �  � ColumnDefinitions 5)      �� 5*      $
��1.0* �6'   66   �� 5+      $
��4.5* �6'   66   .+�5-      �� $��80��6   $��1��6'   $��Disabled=�5.      $��Disabled=�5/      ��50      �� 51      .R�52      ��  �� Orientation$ 
Horizontal=�6)   6D   53      .@�55      �� $	��100��6#    �� 
IsSelected . .��56      �� $ Vertical=�6%   .+�57      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ 
Restaurant=�66   
���� K�$��50��59   6   $��25��6A   $��Center=�5:   6   6S   �� 5;      $��Bottom=�6(   $��15(�5<   (   $��50��5=   (   
���� K�Pubs5>   /   5?      5@      �� 5A      $	��100��6#   .��5B      �� $ Vertical=�6%   .+�5C        $
 Star=�66   
���� K�$��50��5E   6   $��25��6A   $��Center=�5F   6   6S   �� 5G      $��Bottom=�6(   $��15(�5H   (   $��50��5I   (   
���� K�
Favorite5J   3   5K      .   (System.Windows.Interactivity.Interaction	   Triggers	 5L      /   )System.Windows.Interactivity.EventTrigger  5M      
   	EventName$
 Selected��6-   .   (System.Windows.Interactivity.TriggerBase   Actions. 5N   "   6   0System.Windows.Interactivity.InvokeCommandAction     Command 68   �� *FavoritePubSelectedCommand+5O      5Q      �� 5R      $	��100��6#   .��5S      �� $ Vertical=�6%   .+�5T        $ Feedback=�66   
���� K�$��70��5V   6   $��25��6A   $��Center=�5W   6   6S   �� 5X      $��Right=�6(   $��Center=�5Y   (   $��15(�5Z   (   $��70��5[   (   
���� K�
Feedback5\   3   5]      	 5^        5_      $
 Selected��6-   . 5`   "      68   �� *FeedbackSelectedCommand+5a      5c      �� 5d      $	��100��6#   .��5e      �� $ Vertical=�6%   .+�5f        $ Event=�66   
���� K�$��90��5h   6   $��25��6A   $��Center=�5i   6   6S   �� 5j      $��Center=�6(   $��15(�5k   (   
���� K�Saved Events5m   7   5n      	 5o        5p      $
 Selected��6-   . 5q   "      68   �� *SavedEventsSelectedCommand+5r      5t      5u      5v      5w      5�      5�      