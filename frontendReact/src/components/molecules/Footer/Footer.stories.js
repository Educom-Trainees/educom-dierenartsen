import React from 'react';
import Footer from './Footer';

export default {
  title: 'MOLECULES/Footer',
  component: Footer,
  argTypes: {
    leftText: { control: 'array' },
    rightText: { control: 'array' },
  },
};

const Template = (args) => <Footer {...args} />;

export const Default = Template.bind({});
Default.args = {
  leftText: ['About Us', 'Contact Us'],
  rightText: ['Copyright &copy 2023 HappyPaw'],
};
