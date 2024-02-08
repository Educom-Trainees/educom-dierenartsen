import React from "react";
import Menu from "./Menu1";
import { faHome, faBell, faCog } from '@fortawesome/free-solid-svg-icons';

const MenuStory = {
    title: 'ATOMS/Menu', 
    component: Menu,
    argTypes: {
      isOpen: { control: 'boolean' },
    },
  };
  
  const Template = (args) => <Menu {...args} />;

  export const OpenMenu = Template.bind({});
  OpenMenu.args = {
    isOpen: true,
    options: [
      { label: 'Home', icon: faHome },
      { label: 'Notifications', icon: faBell },
      { label: 'Settings', icon: faCog },
    ],
  };
  
  export const ClosedMenu = Template.bind({});
  ClosedMenu.args = {
    isOpen: false,
    options: [], // You can provide an empty array for a closed menu if needed
  };

  export default MenuStory