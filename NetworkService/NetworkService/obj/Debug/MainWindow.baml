   M S B A M L   `   `   `  ����I  ENetworkService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:NetworkServiceNetworkService  5   	   ;"clr-namespace:NetworkService.ViewsNetworkService.Views  5   	   C&clr-namespace:NetworkService.ViewModelNetworkService.ViewModel  5   	       NetworkService.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:NetworkService     5   	   4views"clr-namespace:NetworkService.Views     5   	   <	viewModel&clr-namespace:NetworkService.ViewModel     5   	   
������   � AllowsTransparency  .  � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � Title$ 
MainWindow��5   	   $	��620��6   $	��820��6)    � DataContext 5      2   ,NetworkService.ViewModel.MainWindowViewModel  5   
    � 	Resources 5       �� DataType3   -NetworkService.ViewModel.NetworkDataViewModel*   $NetworkService.Views.NetworkDataView3   -NetworkService.ViewModel.DragAndDropViewModel*   $NetworkService.Views.DragAndDropView1   +NetworkService.ViewModel.ChartDataViewModel(   "NetworkService.Views.ChartDataView��%�   (��       5      *, +)(�� 2     5      *, +)(�� d     5      *, +)�� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      5       J� InputBindings 5"      �� 5#   
   
 �� Key$ F1��6   	 �� CommandParameter$	 networkData��6=   
 �� Command
 6   �� *
NavCommand+6=   �� 5$   
   $ F2��6   $	 dragAndDrop��6=   
 6   �� *
NavCommand+6=   �� 5%   
   $ F3��6   $	 	chartView��6=   
 6   �� *
NavCommand+6=   �� 5&   
   $ F4��6   $	 first��6E   
 6   �� *AddShortcutCommand+6E   �� 5'   
   $ F5��6   $	 second��6E   
 6   �� *AddShortcutCommand+6E   �� 5(   
   $ F6��6   
 6   �� *DeleteShortcutCommand+�� 5)   
   $ F7��6   
 6   �� *UndoShortcutCommand+.��5-      �� ���#653239 �� CornerRadius$ 55��6"   ._�5/   
   �  � RowDefinitions 50      �� 51      $��* �6    �� 52      $��7* �6    �� 53      $��* �6    .+�56      � $��0��6   .+�57      �� $��Termometers��6   ���#BDBDBD$
��Bold"�6D   $��40(�6V   $��Center=�6d   $��Center=�6�   �� 58      
������ 
�������
������ $��DemiBold"�6�   $��Center=�6�   $��X��6�   $��Right=�6�   $��	0 15 15 0q�6�   $	��Top=�6�   $��48��6  $��29��6  $��18(�6"  ��6   �� *CloseCommand+6"  �� 59      $��Bottom=�6   $	��5 0q�67   ���#BDBDBD6D   5:      � 5<      $��1��6    +� FocusedElement 6    ��  �� ElementName$ CurrentViewModel��.+�5=      �� ��6!   �� *CurrentViewModel+�� 5>      $��Bottom=�6   $	��5 0q�67   ���#BDBDBD6D   5?      � 5A      $��2��6   $��Center=�6    $��Center=�6=    � ColumnDefinitions 5B      �� 5C      $��* �6'   �� 5D      $��* �6'   �� 5E      $��* �6'   .+�5G      	� $��2��6   $��	10,0,30,0q�6.   $��Drag and Drop��6A   ���#BDBDBD$��dragAndDrop��6�    d� 	IsChecked$
 TrueY�6�   ��6o   �� *
NavCommand+6�   	� 5H      $��1��6   $��Network Data��6.   ���#BDBDBD$��networkData��6z   $
 TrueY�6�   $��
-54,0,54,0q�6�   ��6[   �� *
NavCommand+6�   	� 5I      $��2��6   $��
Chart view��6.   ���#BDBDBD$��	chartView��6x   $��160,0,-160,0q�6�   ��6Y   �� *
NavCommand+6�   5J      5K      5L      5M      