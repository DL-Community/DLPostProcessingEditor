using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UI.Tab
{
    public class TabGroup : MonoBehaviour
    {
        public GameObject block;


        List<Tab> Tabs { get; set; }
        public int? currentSelection;
        public bool isCurrentShowing => currentSelection != null;
        private void Start()
        {
            if(block)
                block.SetActive(false);
        }
        public void AddTab(Tab tab)
        {
            if(Tabs == null)
                Tabs = new List<Tab>();
            if (!Tabs.Contains(tab))
            {
                Tabs.Add(tab);
                tab.ID = Tabs.IndexOf(tab);
            }
        }

        public void ShowTab(int showTab, bool isOnMouseHover = false, bool tapToHide = false)
        {
            if (isOnMouseHover)
            {
                if (isCurrentShowing)
                {
                    ShowTab(showTab);
                }
            }
            else if (!isOnMouseHover)
            {
                if (isCurrentShowing && tapToHide)
                {
                    CloseAllTabs();
                }
                else
                {
                    ShowTab(showTab);
                }
            }
        }
        public void ShowTab(int showTab)
        {
            CloseAllTabs();
            Tabs[showTab]?.ShowTab();
            currentSelection = showTab;
            if (block)
                block.SetActive(true);
        }
        public void CloseAllTabs()
        {
            foreach (Tab tab in Tabs)
            {
                tab?.ShowTab(false);
            }
            if (block)
                block.SetActive(false);
            currentSelection = null;
        }

    }

}
