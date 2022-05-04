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
            block?.SetActive(false);
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
        public void ShowTab(int showTab)
        {
            CloseAllTabs();
            Tabs[showTab]?.TabItem?.SetActive(true);
            currentSelection = showTab;
            block?.SetActive(true);
        }
        public void CloseAllTabs()
        {
            foreach (Tab tab in Tabs)
            {
                tab?.TabItem?.SetActive(false);
            }
            block?.SetActive(false);
            currentSelection = null;
        }

    }

}
