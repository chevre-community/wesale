/* eslint-disable @next/next/no-page-custom-font */
/* eslint-disable @next/next/no-title-in-document-head */
// eslint-disable-next-line @next/next/no-document-import-in-page
import { Head } from "next/document";

const NextHelmet = ({ title, desc, keywords }) => {
  return (
    <>
      <title>{title}</title>
      <meta httpEquiv="Content-Type" content="text/html;charset=UTF-8" />
      <meta name="description" content={desc} />
      <meta name="og:description" content={desc} />
      <meta name="og:title" content={title} />
      <meta name="keywords" content={keywords} />
      <meta name="og:type" content="website" />
      <meta name="author" content="Chevre | Wesale" />
      <link rel="shortcut icon" href="/static/WeSale.svg" type="image/x-icon" />
      <link rel="apple-touch-icon" href="/static/WeSale.svg" />
      <link rel="preconnect" href="https://fonts.googleapis.com" />
      <link
        rel="preconnect"
        href="https://fonts.gstatic.com"
        crossOrigin="true"
      />
      <link
        href="https://fonts.googleapis.com/css2?family=Inter:wght@300;400;500;600;700&display=swap"
        rel="stylesheet"
      />
    </>
  );
};

export default NextHelmet;
