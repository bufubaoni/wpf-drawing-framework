   M S B A M L   `   `   `  ����>  :Map, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null&clr-namespace:Map;assembly=MapMap  5   	    Demo   Demo.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .mapclr-namespace:Map;assembly=Map     5   	     � Title$  
MainWindow��5   	   $	��350��6   $	��600��6)   .��5      �  � RowDefinitions 5   
   �� 5      $��28 �6   6*   �� 5	      $��43 �6   6*   �� 5
      $��* �6   6)   �� 5      $��30 �6   6*   .+�5   
   o� $��0��6   $��Stretch=�6   $��Center=�68   $��15(�6Z   .@�5      m� $
��File��6   $��50��6&   $��Center=�61   .@�5      m� -   5         m�Name$ menuItem_Open��5   )   $
��Open��6   6^   5      5      `� 5   
   $��1��6   .�5      c� .@�5      �� -   5         ��Name$ btnWholeMap��5      .��5      �� $��Icons/fullextend1.png��6   $
��None=�6;   6L   5      �� 5      �� 5      -   5        $ btnTranslate��5      .��5      �� $��Icons/pan.png��6   $
��None=�63   6D   5      �� 5      �� 5      -   5        $ btnScale��5      .��5      �� $��Icons/zoom1.png��6   $
��None=�65   6F   5      �� 5       �� 5!      -   5        $ btnMax��5!      .��5"      �� $��Icons/zoomin1.png��6   $
��None=�67   6H   5#      �� 5$      �� 5%      -   5        $ btnMin��5%      .��5&      �� $��Icons/zoomout1.png��6   $
��None=�68   6I   5'      �� 5(      �� 5)      -   5        $ btnPick��5)      .��5*      �� $��Icons/pick2.png��6   $
��None=�65   6F   5+      �� 5,      �� 5-      -   5        $ 	btnSelect��5-      .��5.      �� $��Icons/select.png��6   $
��None=�66   6G   5/      �� 50      �� 51      -	   5        $ btnReversSelect��51      .��52      �� $��Icons/selectreverse.png��6   $
��None=�6=   6N   53      54      55      �� 56   
   $��2��6   $��1��6"   .@�57      �� $	��Map��6   .��58         Map.MainCanvas  -
   5          Name$ 
mainCanvas��58   !   ���	#FF272323}�. .+�59         Map.PointVisualHost  -   5          Name$ m_PointVisualHost��59   *   $
��auto��6E   $
��auto��6S   $��Stretch=�5:   "   $��Stretch=�6@    �� Left$ 0��6\   
 �� Top$ 0��6l   6}      Map.LineVisualHost  5;      -   5          Name$ m_LineVisualHost��5;   )   $
��auto��6C   $
��auto��6Q   $��Stretch=�5<   -   $��Stretch=�6K   $ 0��6g   $ 0��6w   6�   5=      5>      5@      �� 5B   
   $��3��6   .@�5C      �� -   5        	 ��Name$	 lblCoordinate��5C      $��Center=�6+   6H   5D      5E      5F      