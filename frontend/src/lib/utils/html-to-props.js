export default function htmlToProps(html, tag) {
  if (!tag) {
    return (
      <>{html}</>
    )
  }

  return (
    <tag>
      {html}
    </tag>
  )
}