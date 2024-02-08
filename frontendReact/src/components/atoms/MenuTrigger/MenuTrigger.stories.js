import React from 'react';
import MenuTrigger from './MenuTrigger'; // Update the import path based on your project structure
import { faHome, faUser, faPen, faPaw } from '@fortawesome/free-solid-svg-icons';
import { faTwitter} from '@fortawesome/free-brands-svg-icons'

const MenuTriggerMeta = {
  title: 'ATOMS/MenuTrigger',
  component: MenuTrigger,
  argTypes: {
    type: { name: 'Type' },
  },
};

const Template = (args) => <MenuTrigger {...args} />;

export const OpenMenu = Template.bind({});
OpenMenu.args = {
  type: 'option-1',
  options: [  // Add this line to include the options prop
    { label: 'Home', icon: faHome },
    { label: 'Contact', icon: faPen },
    { label: 'About', icon: faPaw },
    { label: 'Login', icon: faUser },
    { label: 'Socials', icon: faTwitter },
  ],
};

export const ClosedMenu = Template.bind({});
ClosedMenu.args = {
  type: 'option-1',
  options: [], // You can provide an empty array for a closed menu if needed
};

export default MenuTriggerMeta;