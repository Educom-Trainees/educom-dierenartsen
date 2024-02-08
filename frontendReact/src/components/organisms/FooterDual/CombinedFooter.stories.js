import React from 'react';
import CombinedFooter from './CombinedFooter'; // Adjust the path to your CombinedFooter component
import { faFacebook, faTwitter, faInstagram } from '@fortawesome/free-brands-svg-icons';

export default {
  title: 'ORGANISMS/CombinedFooter',
  component: CombinedFooter,
};

const socialIcons = [
  { icon: faFacebook, link: 'https://www.facebook.com/' },
  { icon: faTwitter, link: 'https://twitter.com/' },
  { icon: faInstagram, link: 'https://www.instagram.com/' },
  // Add more social icons as needed
];

const Template = (args) => <CombinedFooter {...args} />;

export const Default = Template.bind({});
Default.args = {
  leftText: ['Left Text 1', 'Left Text 2'],
  rightText: ['Right Text 1', 'Right Text 2'],
  socialIcons: socialIcons,
};