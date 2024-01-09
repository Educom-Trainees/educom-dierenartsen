import React from 'react';
import MenuButton from './MenuButton';

export default {
  title: 'ATOMS/MenuButton',
  component: MenuButton,
  argTypes: {
    children: { control: 'text' }, 
  },
};

const Template = (args) => <MenuButton {...args} />;

export const Default = {
  args: {
    children: 'Menu',
  },
};