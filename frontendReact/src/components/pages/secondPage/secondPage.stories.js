import React from 'react';
import SecondPage from './secondPage';

export default {
  title: 'Pages/SecondPage',
  component: SecondPage,
};

const Template = (args) => <SecondPage {...args} />;

export const Default = Template.bind({});
Default.args = {
  // You can pass arguments to customize the appearance of the HomePage
};

// export const HeaderStory = () => <Header /* your props here */ />;
// export const CardStory = () => <Card /* your props here */ />;
// export const FooterStory = () => <Footer /* your props here */ />;