   M S B A M L   `   `   `  ����L  HChocoholicsPortal, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ChocoholicsPortalChocoholicsPortal  5   	   )    #ChocoholicsPortal.AddServiceBilling   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:ChocoholicsPortal     5   	     � Title$  AddServiceBilling��5   	   $��438.655��6#   $��434.454��64   .��5	      � ��5
   
   �� 5       �� Color$ 	#FF5C7BA8��6   .+�5   
   �� 
�������$	��346��6!   $��
10,52,10,0q�6.   
���   �$	��Top=�6Q   �� 5   
   -   5         ��Name$ label��5      $��Add Billing For A Service��6   $��
87,13,73,0q�6C   $	��Top=�6W   $��Segoe UI Semibold)�6o   $��22(�6�   
�������6�   �� 5   
   -   5        $ 
label_Copy��5      $��
Member ID:��6$   $
��Left=�69   $��	49,94,0,0q�6T   $	��Top=�6g   $	��111��6   �� 5   
   -   5        $ label_Copy1��5      $��Look-up Service:��6%   $
��Left=�6@   $��
49,144,0,0q�6[   $	��Top=�6o   $	��111��6�   �� 5   
   -   5         ��Name$ memberIDTextbox��5      $��26��6+   $��181,94,125,0q�67    �� TextWrapping$
 Wrap=�6M   $	��Top=�6a   6y   �� 5   
   -   5        $ serviceCodeTextbox��5      $��26��6.   $��181,144,125,0q�6:   $
 Wrap=�6Q   $	��Top=�6e   �� 5   
   -   5         ��Name$ SubmitButton��5      $��Submit��6'   $��181,0,170,20q�68   $��Bottom=�6N   $��26��6i   6u   �� 5   
   -   5        $ label_Copy2��5      $��Date Service Given:��6%   $
��Left=�6C   $��
49,186,0,0q�6^   $	��Top=�6r   (  "System.Windows.Controls.DatePicker  5   
   -   5          Name$ ServiceDatePicker��5      $��181,186,127,0q�60   $	��Top=�6G   $��26��6_   �� 5   
   -	   5        $ validatedLabel��5      $��	Validated��6(   $��Right=�6<   $��	0,94,38,0q�6X   $	��Top=�6k   �� 5   
   -
   5        $ CommentsTextBox��5      $��181,264,38,66q�6+   $
 Wrap=�6B   6V   �� 5   
   -   5        $ label_Copy3��5      $��	Comments:��6%   $
��Left=�69   $��
49,254,0,0q�6T   $	��Top=�6h   $	��111��6�   �� 5   
   -   5        $ CostTextbox��5      $��26��6'   $��181,223,125,0q�63   $
 Wrap=�6J   $	��Top=�6^   �� 5   
   $��Expected Cost:��6   $
��Left=�6)   $��
49,223,0,0q�6D   $	��Top=�6X   $	��111��6p   5      5      