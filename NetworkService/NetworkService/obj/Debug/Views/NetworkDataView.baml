   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:NetworkService.ViewsNetworkService.Views  5      C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5      /clr-namespace:NetworkServiceNetworkService  5      ;"clr-namespace:NetworkService.ModelNetworkService.Model  5	      *    $NetworkService.Views.NetworkDataView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      4local"clr-namespace:NetworkService.Views     5      <	viewModel&clr-namespace:NetworkService.ViewModel     5      0defaultclr-namespace:NetworkService     5      3data"clr-namespace:NetworkService.Model     5	      c _System.Windows.Interactivity, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  6>   |�. .��5      � ���#EAF9D7  � RowDefinitions  5   
   �� 5      $	��350 �6   �� 5      $	��120 �6   .+�5   
   � $��1��6   $	��120��6   $	��800��6)   $
��Left=�65    � ColumnDefinitions 5      �� 5      $	��460 �6#   �� 5      $	��340 �6#   .+�5      �� $	��120��6   $	��460��6&   $��0��62   .+�5      �� $��10 5 0 0q�6   $
��Left=�6.   $
��auto��6I   $
��auto��6W   $��ID��6d   �� 5      $��
50 -17 0 0q�6e    �� TextAlignment$ Center=�6y   $
��Left=�6�   $��20��6�   $��40��6�   $��DemiBold"�6�   ���#ccc7b9��6   �� *	IdValid+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�6�   �� 5      $��
95 -20 5 0q�6   $
��Left=�60   $��20��6K   $	��100��6W   
���  ����6c   �� *ValidationErrors[ID]+6�   �� 5      $��10 5 0 0q�6   $
��Left=�6.   $��Center=�6I   $
��Name��6d   �� 5      $
��Left=�6g   $��
50 -17 0 0q�6�   $ Center=�6�   $��20��6�   $	��100��6�   $��DemiBold"�6�   ���#ccc7b9��6   �� *	NameValid+$ TwoWay=�$ PropertyChanged=�6�   �� 5       $��50 3 5 0q�6   $
��Left=�6.   $��15��6I   $	��100��6U   
���  ����6a   �� *ValidationErrors[Naziv]+6�   �� 5"      $��10 5 0 0q�6   $
��Left=�6.   $��Center=�6I   $
��Type��6d   �� 5#      $��
50 -17 0 0q�6   $
��Left=�6/    �� SelectedIndex$ 0��6�   $��DemiBold"�6�   $	��100��6�   $��23��6�   ���#ccc7b9 �� SelectedItem 6J   �� *
TipValid+$ OneWayToSource=���5$      -  'System.Windows.Data.CompositeCollection  5%      �� 5&       �� 
Collection 62   �� #   NetworkService.Model.DataBase   TermometersTypesList	 �� Source#	 Z 5'      5)      �� 5*      $��50 3 0 0q�6   $
��Left=�6.   $��15��6I   $	��100��6U   
���  ����6a   �� *ValidationErrors[Tip]+6�   �� 5,      $	��Add��68   $
��Left=�6F   $��160 -160 0 0q�6a   $��25��6w   $��90��6�   ���#653239
���������6   �� *
AddCommand+5-      �� 5.      $��Delete��6;   $
��Left=�6L   $��160 -80 0 0q�6g   $��25��6|   $��90��6�   ���#653239
���������6   �� *DeleteCommand+6�   5/      �� 51      $��1��6   $��5,5,10,0q�6)   .+�52      �� $
��Left=�6   $��Legend:��68   $��16(�6G   �� 53      $
��Left=�6   $��F4: Create Type RTD��68   $��16(�6S   �� 54      $
��Left=�6   $"��F5: Create Type Termo Sprega��68   $��16(�6\   �� 55      $
��Left=�6   $$��F6: Delete selected termometer��68   $��16(�6^   �� 56      $
��Left=�6   $��F7: Undo last action��68   $��16(�6T   57      58      � 5;   
   $��0��6    5<      �� 5=      $	��250 �6#   �� 5>      $	��550 �6#   .+�5@      � $��0��6   ���#EAF9D9  5A      �� 5B      $	��100 �6$   �� 5C      $��70 �6$   �� 5D      $	��100 �6$   �� 5E      $	��100 �6$   .+�5G      � $��0��6   $��Center=�6$    5H      �� 5I      $	��120 �6+   �� 5J      $	��130 �6+   .+�5L      �� $��0��6!   .+�5M      	� -   5        
 	�Name$
 Lower��5M   &   $
��Bold"�65    	� 	GroupName$ Search��6G   $��
Lower than��6v   $��5 0 5 0q�6�    d� 	IsChecked 6Z   �� *Lower+6�   	� 5N      -   5        $
 Higher��5N   &   $
��Bold"�66   $ Search��6H   $��Higher than��6x   $��5 0 5 0q�6�    6[   �� *Higher+6�   	� 5O      -   5        $
 Equal��5O   &   $
��Bold"�65   $ Search��6G   $��Equal��6v   $��5 0 5 0q�6�    6Z   �� *Equal+6�   5P      �� 5Q      $��1��6!   $
��Left=�61   .+�5R      �� $	��Id:��6    �� 5S      -   5         ��Name$ 	TextBoxId��5S   "   
 � Tag$  Search��6R   $��51��6`   $��25��6k   $��5 0 10 5q�6w    � ToolTip$ 
Unesite ID��6�   ��65   �� *
FilterText+6�   �� 5T      
���  ��6%   5U      5V      � 5W      $��1��6   .+�5X      �� $
��Left=�6!   $	��Top=�6=   $	��250��6U   .+�5Y      �� $��Type:��6    �� 5Z      -   5         ��Name$ ComboBoxFilter��5Z   #    �� Text$ Select option��6�   $	��120��6�   $��25��6�   ��6<   �� *TipoviComboBox+$ TwoWay=�$ PropertyChanged=� 6�   �� *SelectedFilterTip+6�   5[      5\      � 5]      $��2��6   .+�5^      �� .+�5_      �� -   5         ��Name$ ButtonSearch��5_   !   $��Filter��6Y   $
��Bold"�6k   $��82��6}   $��20��6�   $��5 5 0 5q�6�   $ Kliknite za filter��6�   ���#653239
���������67   �� *FilterCommand+6�   �� 5`      -   5        $ ButtonReset��5`   !   $��Reset��6W   $
��Bold"�6g   $	��100��6y   $��20��6�   $��5 5 0 5q�6�   $( "Klik za ponistavanje opcije Filter��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   ���#653239
���������66   �� *ResetCommand+ ^� 	IsEnabled 6�   �� *FeedBackOnOffND+$ PropertyChanged=�6^  5a      5b      � 5c      $��3��6   .+�5d      �� $��Center=�6!   .+�5e      �� -   5         ��Name$ ValidValuesOnlyCheckbox��5e   #   $��Valid Values Only��6D    6`   �� *ValidValuesOnly+$ TwoWay=�5f      5g      5h      &   System.Windows.Controls.DataGrid  5j      $��1��6      CanUserAddRows .     RowBackground �#ccc7b9���#ccc7b9   AutoGenerateColumns .   6>   �� *SelectedTermometer+��6j   �� *Termometers+$ PropertyChanged=�   ColumnHeaderStyle 5l      �� 5m       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5n      ��  �� Property � �� �� Value �#ccc7b967   �� 5o       � ��$ 20��66   �� 5p       � ��$ 20(�65   �� 5q       � ��$ Center=�6@   5r         Columns 5v      0  *System.Windows.Controls.DataGridTextColumn  5x      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6L       FontSize$  18Q�6V   !   
IsReadOnly! . 1  +System.Windows.Controls.DataGridBoundColumn"   Binding" 65   �� *ID+#   ElementStyle# 5y      �� 5z      " ��6$   .�5{   "   ��  � ��$ Center=�6H   5|      5~        5�      $ Naziv��6)   $ 5* 6R   $  18Q�6]   ! . " 68   �� *Naziv+# 5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ Center=�6H   5�      5�        5�      $	 Tip��6)   $ 5* 6X   $  18Q�6c   ! . " 66   �� *Tip.NazivTipa+# 5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ Center=�6H   5�      5�        5�      $ Vrednost��6)   $ 5* 6X   $  18Q�6c   ! . " 6;   �� *
Vrednost+# 5�      �� 5�      " ��6$   .�5�   "   ��  � ��$ Center=�6H   5�      5�      5�      5�      5�      5�      