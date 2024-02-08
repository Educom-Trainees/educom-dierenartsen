import React from 'react';
import FooterText from './FooterText';

export default {
  title: 'ATOMS/FooterText',
  component: FooterText,
  argTypes: {
    text: { control: 'text' },
    text: { control: 'text' },
  },
};

const Template = (args) => <FooterText {...args} />;

export const Default = Template.bind({});
Default.args = {
  text: 'About HappyPaw',
  text: 'Contact',
};