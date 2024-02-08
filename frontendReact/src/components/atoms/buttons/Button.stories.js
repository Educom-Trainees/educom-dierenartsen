// button.stories.js
import React from 'react';
import Button from './Button';
import { library } from '@fortawesome/fontawesome-svg-core';
import { faCalendarDays, faBars, faArrowLeft } from '@fortawesome/free-solid-svg-icons';

library.add(faCalendarDays);

export default {
  title: 'ATOMS/Button',
  component: Button,
  argTypes: {
    variant: { control: 'text' }, 
    children: { control: 'text' },
  },
};

const Template = (args) => <Button {...args} />;

export const Primary = Template.bind({})
Primary.args = {
  variant:'primary',
  label: 'Plan afspraak',
};

export const Secondary = Template.bind({})
Secondary.args = {
  variant:'secondary',
  label: 'Volgende',
};

export const Return = Template.bind({});
Return.args = {
  size: 'return',
  icon: faArrowLeft,
};

export const MenuHamburger = Template.bind({});
MenuHamburger.args = {
  size: 'menuHamburger',
  icon: faBars,
};

export const ExtraSmall = Template.bind({});
ExtraSmall.args = {
  size: 'extraSmall',
  label: 'Extra Small',
};

export const Small = Template.bind({});
Small.args = {
  size: 'small',
  label: 'Small',
};

export const Medium = Template.bind({});
Medium.args = {
  size: 'medium',
  label: 'Medium',
};

export const Large = Template.bind({});
Large.args = {
  size: 'large',
  label: 'Large',
};