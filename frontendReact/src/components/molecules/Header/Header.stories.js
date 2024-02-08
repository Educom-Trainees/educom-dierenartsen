import React from 'react';
import Header from './Header';
import { faHome, faPaw } from '@fortawesome/free-solid-svg-icons'

export default {
  title: 'Molecules/Header',
  component: Header,
  argTypes: {
    logoSrc: { control: 'text' },
    logoAlt: { control: 'text' },
    onHamburgerClick: { action: 'clicked' },
    menuOptions: { control: 'array' },
  },
};

const Template = (args) => <Header {...args} />;

export const Default = Template.bind({});
Default.args = {
  logoSrc: 'path/to/your/logo.png',
  logoAlt: 'Your Logo',
  onHamburgerClick: () => {},
  menuOptions: [
    { label: 'Option 1', icon: faHome },
    { label: 'Option 2', icon: faPaw },
  ]
};